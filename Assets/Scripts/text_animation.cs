using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами (canvas, text, button ....)
using UnityEngine.SceneManagement; //Подключаем библиотеку для управления сценами

//Этот код text_animation создает анимацию печатающий машинки в TEXT UI объектах
public class text_animation : MonoBehaviour
{
    string text_ui_element; //Переменная строки, отвечающая за запись текста из UI элемента

    public GameObject next_station_textUi, go_on, ingredients_go;
    //публичные переменные GameObject (настраиваются в компонентах)
    //GameObject next_station_textUi - UI объект текст next_station_text ("*что бы продолжить нажми любую кнопку")
    //GameObject go_on - Следующий объект, после этого
    //GameObject ingredients_go - объкт "ингредиента", который будет следовать по "инструкции"

    public bool move_Ingredients, last_station, finish_burgers, finish;
    //публичные логические перемменные (настраиваются в компонентах)
    //bool move_Ingredients - если включен, то ingredients_go двигается к точке
    //bool last_station - если включен, то это слайд будет последним 
    //finish_burgers - определяет конец уровня. после того как бургер будет собран, 
    //finish - если включен, то определяет конец всех слайдов

    //Функция Start работает один раз при старте скрипта
    void Start()
    {
        //записывает в переменную text_ui_element текст из этого(объект к которому привязан этот объект) TEXT UI объекта 
        text_ui_element = GetComponent<Text>().text;
        //запускает функцию - IEnumerator animation_text_ui()
        StartCoroutine("animation_text_ui", text_ui_element);
    }

    //Функция Update вызывается раз за кадр.
    void Update()
    {
        //При нажатие любой клавиши, в том числе правой и левой кнопки мыши, значит условие верно
        if (Input.inputString != "" || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //если объект next_station_textUi включен, значит условие верно
            if (!next_station_textUi.activeSelf)
                //запускает функцию stop_animation_textUi()
                stop_animation_textUi();
            //если слайд не последний
            else if (!last_station)
                //запускает функцию next_station()
                next_station();
        }
    }
    //В Unity корутины регистрируются и выполняются до первого yield с помощью метода StartCoroutine
    IEnumerator animation_text_ui(string stext)
    {
        int i = 0;

        //переменная end нужна для того, что бы скрипт не печатал теги <color>
        bool end = false;

        //цикл while создает анимация 'печатающийся текст'
        while (i <= stext.Length)
        {
            if (i + 1 <= stext.Length)
            {
                //если курсор дошел до символа '<' и если след символ 'c' то условие верно
                if (stext[i] == '<' && stext[i + 1] == 'c')
                {
                    //пропускант 15 символов, тем самым теги <color> печатаются без анимации сразу
                    i += 15;

                    end = true;
                }
                //если курсор дошел до символа '<' и если след символ '/' то условие верно
                else if (stext[i] == '<' && stext[i + 1] == '/')
                {
                    //пропускант 8 символов, тем самым теги <color> печатаются без анимации сразу
                    i += 8;

                    end = false;
                }
            }

            //если end = true, то текст печатается с тегом </color> на конце
            if (end)
            {
                GetComponent<Text>().text = stext.Substring(0, i) + "</color>";
            }           
            //просто печатает текст по символу
            else
                GetComponent<Text>().text = stext.Substring(0, i);
            
            i++;
            
            //скорость печатания текста
            yield return new WaitForSeconds(0.05f);
        }
        //запускает функцию stop_animation_textUi()
        stop_animation_textUi();
    }

    //функция stop_animation_textUi останавливает анимацию 
    void stop_animation_textUi()
    {
        //отанавливает все IEnumerator корутины
        StopAllCoroutines();
        //после остановки анимации, текст объекта UI дописывается полностью моментально
        GetComponent<Text>().text = text_ui_element;

        //если bool finish ложно
        if (!finish)
        {
            //если bool move_Ingredients ложно
            if (!move_Ingredients)
            {
                //если bool last_station ложно
                if (!last_station)
                    //включает объект next_station_textUi
                    next_station_textUi.SetActive(true);
                else
                {
                    //включает скрипт return_ingredients_pos, который возвращает все ингредиенты на места
                    GetComponent<return_ingredients_pos>().enabled = true;
                }
            }
            else
            {
                //включает скрипт move_Ingredients_script на объектах ingredients_go
                ingredients_go.GetComponent<move_Ingredients_script>().enabled = true;
            }
        }
    }

    //функция next_station() листает слайды
    void next_station()
    {
        // выполняется, если finish == false, то есть если это не последний слайд
        if (!finish)
        {
            //если это последний слайд в сценах с бургерами
            if (finish_burgers)
                //запускается сцена номер 2
                SceneManager.LoadScene(2);
            else
            {
                //включает след слайд
                go_on.SetActive(true);
                //выключает объект next_station_textUi
                next_station_textUi.SetActive(false);
                //выключает этот объект
                gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //Подключаем библиотеку для работы со сценами
using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 

//этот скрипт отвечает за все объекты в главном меню
public class main : MonoBehaviour
{
    //создаем публичные переменные GameObject
    //название переменных схожи с названием этих объектов на сцене
    public GameObject continue_btn, new_game_btn, callout, menu_text, set_name_text, start_text, noname_text, exitgame_btn;

    //void Start() запускается один раз во время первого запуска скрипта
    void Start()
    {
        //проверяем существует ли ключ Name, сохраненный нами ранее
        if (PlayerPrefs.HasKey("Name"))
        {
            continue_btn.GetComponent<Button>().interactable = true;
        }
    }

    //эта функция вызывается через кнопку "новая игра"
    public void new_game()
    {
        //отключаем кнопку continue_btn
        continue_btn.SetActive(false);
        //отключаем кнопку new_game_btn
        new_game_btn.SetActive(false);
        //отключаем кнопку exitgame_btn
        exitgame_btn.SetActive(false);
        //отключаем кнопку menu_text
        menu_text.SetActive(false);
        //изменяем размер и позицию объекта callout (это рамка где весь текст)
        callout.GetComponent<RectTransform>().anchoredPosition = new Vector2(-387.5f, 109.4f);
        callout.GetComponent<RectTransform>().sizeDelta = new Vector2(466, 327.4f);
        //включаем объект set_name_text
        set_name_text.SetActive(true);
    }

    //эта функция вызывается через кнопку set_name_button (во время ввода имени)
    //input_name_text это дочерний объект (set_name_input) ввода объекта set_name_text
    public void GetText(InputField input_name_text)
    {
        //если пользователь не ввел ничего 
        if (input_name_text.text == "")
        {
            //вкобчаем объект noname_text
            noname_text.SetActive(true);
            //сохраняем имя как чмо (записываем его в ячейку Name)
            PlayerPrefs.SetString("Name", ("чмо"));
            //Изменяем * на чмо в тексте объекта start_text
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", "чмо");
        }
        //если пользователь ввел имя то
        else
        {
            //записываем ИМЯ введенное пользователем в ячейку NAME
            PlayerPrefs.SetString("Name", (input_name_text.text));
            //Изменяем * на ИМЯ в тексте объекта start_text
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", input_name_text.GetComponent<InputField>().text);
            //включаем объект start_text
            start_text.SetActive(true);
        }
        //отключаем объект set_name_text
        set_name_text.gameObject.SetActive(false);
    }
    //эта функция вызывается через кнопку "продолжить"
    public void contunue_game()
    {
        //загружаем сцену под номером 2
        SceneManager.LoadScene(2);
    }
    //эта функция вызывается через кнопку exitgame
    public void ExitGame()
    {
        //выходит из игры
        Application.Quit();
    }
}

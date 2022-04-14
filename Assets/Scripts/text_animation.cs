using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 
using UnityEngine.SceneManagement; //Подключаем библиотеку для работы со сценами
public class text_animation : MonoBehaviour
{
    string text_ui_element;
    public GameObject next_station_textUi, go_on, ingredients_go;

    public bool move_Ingredients, last_station, finish;

    void Start()
    {
        text_ui_element = GetComponent<Text>().text;
        StartCoroutine("animation_text_ui", text_ui_element);
    }

    void Update()
    {
        if (Input.inputString != "" || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (!next_station_textUi.activeSelf)
                stop_animation_textUi();
            else if (!last_station)
                next_station();
        }
    }

    IEnumerator animation_text_ui(string stext)
    {
        int i = 0;
        bool end = false;
        while (i <= stext.Length)
        {
            if (i + 1 <= stext.Length)
            {
                if (stext[i] == '<' && stext[i + 1] == 'c')
                {
                    i += 15;
                    end = true;
                }
                else if (stext[i] == '<' && stext[i + 1] == '/')
                {
                    i += 8;
                    end = false;
                }
            }

            if (end)
            {
                GetComponent<Text>().text = stext.Substring(0, i) + "</color>";
            }           
            else
                GetComponent<Text>().text = stext.Substring(0, i);
            i++;
            yield return new WaitForSeconds(0.05f);
        }
        stop_animation_textUi();
    }


    void stop_animation_textUi()
    {
        StopAllCoroutines();
        GetComponent<Text>().text = text_ui_element;

        if (!move_Ingredients)
        {
            if (!last_station)
                next_station_textUi.SetActive(true);
            else
            {
                GetComponent<return_ingredients_pos>().enabled = true;
            }
        }
        else
        {
            ingredients_go.GetComponent<move_Ingredients_script>().enabled = true;
        }

    }

    void next_station()
    {
        if (finish)
            SceneManager.LoadScene(0);
        else
        {
            go_on.SetActive(true);
            next_station_textUi.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}

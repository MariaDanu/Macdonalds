using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 

public class replace_text_name : MonoBehaviour
{
    //скрипт отвечает за замену * на имя из сохранения
    //достаточно добавить скрипт на любой объект текста где есть * и скрипт будет работать
    void Start()
    {
        GetComponent<Text>().text = GetComponent<Text>().text.Replace("*", PlayerPrefs.GetString("Name"));
    }
}

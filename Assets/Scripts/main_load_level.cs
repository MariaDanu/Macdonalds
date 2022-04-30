using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //подлкючаем библиотеку для работы со сценами


public class main_load_level : MonoBehaviour
{
    //эта функция отвечает за загрузку сцены 'чизбургер'
    public void chisburger_load_scene()
    {
        //запускаем сцену под номером 3
        SceneManager.LoadScene(3);
    }
    //эта функция отвечает за загрузку сцены 'двойной чизбургер'
    public void double_chisburger_load_scene()
    {
        //запускаем сцену под номером 4
        SceneManager.LoadScene(4);
    }
    //эта функция отвечает за загрузку сцены 'филе о  фиш'
    public void filet_o_fish_scene()
    {
        //запускаем сцену под номером 5
        SceneManager.LoadScene(5);
    }

    //эта функция отвечает за загрузку сцены 'двойной филе о  фиш'
    public void double_filet_o_fish_scene()
    {
        //запускаем сцену под номером 6
        SceneManager.LoadScene(6);
    }

    //эта функция отвечает за кнопку назад 
    public void back_levels_menu()
    {
        //запускаем сцену под номером 2
        SceneManager.LoadScene(2);
    }
    //эта функция отвечает за кнопку меню
    public void back_menu()
    {
        //запускаем сцену под номером 1
        SceneManager.LoadScene(1);
    }
}

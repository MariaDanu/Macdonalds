using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //Подключаем библиотеку для управления сценами

// Этот скрипт отвечает за анимацию превью (mahagame)
public class showpreview : MonoBehaviour
{
    bool loads = true;
    float t;

    private void Start()
    {
        //записываем время в float 
        t = Time.time;
    }
    void Update()
    {
        //если время которую мы записали в t + 2 секунды меньше нынешнего времени, то код выполняется 
        if (t + 2 < Time.time)
        {
            //speed - скорость анимации
            float speed = 0.5f;

            //если loads = true
            if (loads)
            {
                //если объект прозрачный, то код выполняется
                if (gameObject.GetComponent<SpriteRenderer>().color.a < 0.99f)
                {
                    //делает объкт видемым со скоростью speed умноженую на Time.deltaTime
                    //Time.deltaTime это время которое потребовалось для прохождения последнего кадра. нужен для того что изменять плавно прозрачность
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a + speed * Time.deltaTime);
                }
                else
                    loads = false;
            }
            //если loads = false
            else if (!loads)
            {
                //если объект не прозрачный, то код выполняется
                if (gameObject.GetComponent<SpriteRenderer>().color.a > 0.01f)
                {
                    //делает объкт невидемым со скоростью speed умноженую на Time.deltaTime
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a - speed * Time.deltaTime);
                }
                else
                {
                    //если анимация выполнена, то запускается сцена номер 1
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}

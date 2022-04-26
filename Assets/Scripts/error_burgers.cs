using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за возвращение цвета ингредиента, во врема ошибки
public class error_burgers : MonoBehaviour
{
    //скоро с которой меняется цвет
    float speed = 3f;
    void Update()
    {
        //если цвет green < 1 (если объект красный)
        if (gameObject.GetComponent<SpriteRenderer>().color.g < 0.99f) 
            //меняем два цвета green, blue.
            //мы получаем в реально времени цвет по g/b и приповляем к speed умноженную на Time.DeltaTime (для плавности)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, gameObject.GetComponent<SpriteRenderer>().color.g + speed * Time.deltaTime, gameObject.GetComponent<SpriteRenderer>().color.b + speed * Time.deltaTime, 255);
        else
        {
            //order in layer ставим 3 на компонетне Sprite Renderer
            GetComponent<SpriteRenderer>().sortingOrder = 3;
            //если ингредиент вернул свой цвет, то мы отключаем этот скрипт на объекте, дабы он не жрал ресурсы!
            GetComponent<error_burgers>().enabled = false;
        }
    }
}

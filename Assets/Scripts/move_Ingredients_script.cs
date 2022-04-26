using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за самостоятельное движение ингредиентов
public class move_Ingredients_script : MonoBehaviour
{
    public GameObject move_to_go, next_station_text, cam, next_ingredient, same_go;
    //переменные GameObject
    //move_to_go - это объект к которому движутся бургеры (бумага), его можно найти на сцене под названием "Square"
    //next_station_text - это объект так и называется на сцене (текст "что бы продолжить нажмите...")
    //cam - это объект камеры
    //next_ingredient - это объект который должен идти след по последовательности, после этого объекта 
    //same_go - это идентичный объект на сцене (пример: sir , sir (1)) 

    //y_pos - это позиция ингредиента, во время сборки, на объекте move_to_go(Square)
    public float y_pos;

    //bool w_moov - отвечает за то, в каком направление двигаться
    //w_moov = true : движение на изначальную позицию
    //w_moov = false : движение в направление move_to_go(Square)
    //last_ingredient - отвечает за то, последний ли это ингредиент
    public bool w_moov, last_ingredient;

    //pos - начальная позиция в блоке ингредиентов 
    //move_to_vector3 - позиция куда нужно следовать при сборке блюда
    private Vector3 pos, move_to_vector3;

    //работает один раз при запуске скрипта
    void Start()
    {
        //узнаем начальную позицию в блоке ингредиентов  
        pos = transform.position;
        //узнаем куда нужно следовать, по x = move_to_go.transform.position.x, по y = y_pos
        move_to_vector3 = new Vector3(move_to_go.transform.position.x, y_pos, 0);
        //отключаем этот скрипт в начале запуска сцены
        GetComponent<move_Ingredients_script>().enabled = false;
    }

    void Update()
    {
        //w_moov = false : движение в направление move_to_go(Square) 
        if (!w_moov)
        {
            //узнаем по x равна ли позиция move_to_vector3.x
            //если не равна то выполняем
            if (transform.position.x != move_to_vector3.x)
            {
                //двигаем объект со скоростью 15 * Time.deltaTime
                transform.position = Vector3.MoveTowards(transform.position, move_to_vector3, 15 * Time.deltaTime);
            }
            //если объект долетел до позиции
            else
            {
                //отключаем next_station_text
                next_station_text.SetActive(true);
                //отключаем этот скрипт на ингредиенте
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }
        //w_moov = true : движение на изначальную позицию
        else if (w_moov)
        {
            //узнаем равняется ли позиция ингредиета изначальной позиции
            //если нет, то движем объект 
            if (transform.position != pos)
            {
                //двигаем объект со скоростью 15 * Time.deltaTime
                transform.position = Vector3.MoveTowards(transform.position, pos, 15 * Time.deltaTime);
            }
            //если достиг точки
            else
            {
                //включаем BoxCollider2D на игредиенте
                GetComponent<BoxCollider2D>().enabled = true;
                //включаем скрипт на камере (cam) move_mouse_Ingredients_script
                cam.GetComponent<move_mouse_Ingredients_script>().enabled = true;
                //отключаем этот скрипт на этом объекте
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }


    }

}

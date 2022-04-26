using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//это скрипт возвращает все ингредиенты на свои места
public class return_ingredients_pos : MonoBehaviour
{
    //массив объектов ингредиентов 
    public GameObject[] ingredients_go;

    void Start()
    {
        //цикл, который проходит по всем объектам массива ingredients_go[]
        for (int i = 0; i < ingredients_go.Length; i++)
        {
            //включает скрипт move_Ingredients_script на объекте ingredients_go[i]
            ingredients_go[i].GetComponent<move_Ingredients_script>().enabled = true;
            //w_moov = true в скрипте move_Ingredients_script на объекте ingredients_go[i]
            ingredients_go[i].GetComponent<move_Ingredients_script>().w_moov = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_ingredients_pos : MonoBehaviour
{
    public GameObject[] ingredients_go;

    void Start()
    {
        for(int i = 0; i < ingredients_go.Length; i++)
        {
            ingredients_go[i].GetComponent<move_Ingredients_script>().enabled = true;
            ingredients_go[i].GetComponent<move_Ingredients_script>().w_moov = true;
        }
    }
}

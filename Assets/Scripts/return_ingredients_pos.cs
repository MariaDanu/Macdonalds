using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��� ������ ���������� ��� ����������� �� ���� �����
public class return_ingredients_pos : MonoBehaviour
{
    //������ �������� ������������ 
    public GameObject[] ingredients_go;

    void Start()
    {
        //����, ������� �������� �� ���� �������� ������� ingredients_go[]
        for (int i = 0; i < ingredients_go.Length; i++)
        {
            //�������� ������ move_Ingredients_script �� ������� ingredients_go[i]
            ingredients_go[i].GetComponent<move_Ingredients_script>().enabled = true;
            //w_moov = true � ������� move_Ingredients_script �� ������� ingredients_go[i]
            ingredients_go[i].GetComponent<move_Ingredients_script>().w_moov = true;
        }
    }
}
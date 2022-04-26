using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �������� �� ��������������� �������� ������������
public class move_Ingredients_script : MonoBehaviour
{
    public GameObject move_to_go, next_station_text, cam, next_ingredient, same_go;
    //���������� GameObject
    //move_to_go - ��� ������ � �������� �������� ������� (������), ��� ����� ����� �� ����� ��� ��������� "Square"
    //next_station_text - ��� ������ ��� � ���������� �� ����� (����� "��� �� ���������� �������...")
    //cam - ��� ������ ������
    //next_ingredient - ��� ������ ������� ������ ���� ���� �� ������������������, ����� ����� ������� 
    //same_go - ��� ���������� ������ �� ����� (������: sir , sir (1)) 

    //y_pos - ��� ������� �����������, �� ����� ������, �� ������� move_to_go(Square)
    public float y_pos;

    //bool w_moov - �������� �� ��, � ����� ����������� ���������
    //w_moov = true : �������� �� ����������� �������
    //w_moov = false : �������� � ����������� move_to_go(Square)
    //last_ingredient - �������� �� ��, ��������� �� ��� ����������
    public bool w_moov, last_ingredient;

    //pos - ��������� ������� � ����� ������������ 
    //move_to_vector3 - ������� ���� ����� ��������� ��� ������ �����
    private Vector3 pos, move_to_vector3;

    //�������� ���� ��� ��� ������� �������
    void Start()
    {
        //������ ��������� ������� � ����� ������������  
        pos = transform.position;
        //������ ���� ����� ���������, �� x = move_to_go.transform.position.x, �� y = y_pos
        move_to_vector3 = new Vector3(move_to_go.transform.position.x, y_pos, 0);
        //��������� ���� ������ � ������ ������� �����
        GetComponent<move_Ingredients_script>().enabled = false;
    }

    void Update()
    {
        //w_moov = false : �������� � ����������� move_to_go(Square) 
        if (!w_moov)
        {
            //������ �� x ����� �� ������� move_to_vector3.x
            //���� �� ����� �� ���������
            if (transform.position.x != move_to_vector3.x)
            {
                //������� ������ �� ��������� 15 * Time.deltaTime
                transform.position = Vector3.MoveTowards(transform.position, move_to_vector3, 15 * Time.deltaTime);
            }
            //���� ������ ������� �� �������
            else
            {
                //��������� next_station_text
                next_station_text.SetActive(true);
                //��������� ���� ������ �� �����������
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }
        //w_moov = true : �������� �� ����������� �������
        else if (w_moov)
        {
            //������ ��������� �� ������� ���������� ����������� �������
            //���� ���, �� ������ ������ 
            if (transform.position != pos)
            {
                //������� ������ �� ��������� 15 * Time.deltaTime
                transform.position = Vector3.MoveTowards(transform.position, pos, 15 * Time.deltaTime);
            }
            //���� ������ �����
            else
            {
                //�������� BoxCollider2D �� ����������
                GetComponent<BoxCollider2D>().enabled = true;
                //�������� ������ �� ������ (cam) move_mouse_Ingredients_script
                cam.GetComponent<move_mouse_Ingredients_script>().enabled = true;
                //��������� ���� ������ �� ���� �������
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }


    }

}

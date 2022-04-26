using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //���������� ���������� ��� ������ � UI ���������� (canvas, text, button ....)
using UnityEngine.SceneManagement; //���������� ���������� ��� ���������� �������

//���� ��� text_animation ������� �������� ���������� ������� � TEXT UI ��������
public class text_animation : MonoBehaviour
{
    string text_ui_element; //���������� ������, ���������� �� ������ ������ �� UI ��������

    public GameObject next_station_textUi, go_on, ingredients_go;
    //��������� ���������� GameObject (������������� � �����������)
    //GameObject next_station_textUi - UI ������ ����� next_station_text ("*��� �� ���������� ����� ����� ������")
    //GameObject go_on - ��������� ������, ����� �����
    //GameObject ingredients_go - ����� "�����������", ������� ����� ��������� �� "����������"

    public bool move_Ingredients, last_station, finish_burgers, finish;
    //��������� ���������� ����������� (������������� � �����������)
    //bool move_Ingredients - ���� �������, �� ingredients_go ��������� � �����
    //bool last_station - ���� �������, �� ��� ����� ����� ��������� 
    //finish_burgers - ���������� ����� ������. ����� ���� ��� ������ ����� ������, 
    //finish - ���� �������, �� ���������� ����� ���� �������

    //������� Start �������� ���� ��� ��� ������ �������
    void Start()
    {
        //���������� � ���������� text_ui_element ����� �� �����(������ � �������� �������� ���� ������) TEXT UI ������� 
        text_ui_element = GetComponent<Text>().text;
        //��������� ������� - IEnumerator animation_text_ui()
        StartCoroutine("animation_text_ui", text_ui_element);
    }

    //������� Update ���������� ��� �� ����.
    void Update()
    {
        //��� ������� ����� �������, � ��� ����� ������ � ����� ������ ����, ������ ������� �����
        if (Input.inputString != "" || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //���� ������ next_station_textUi �������, ������ ������� �����
            if (!next_station_textUi.activeSelf)
                //��������� ������� stop_animation_textUi()
                stop_animation_textUi();
            //���� ����� �� ���������
            else if (!last_station)
                //��������� ������� next_station()
                next_station();
        }
    }
    //� Unity �������� �������������� � ����������� �� ������� yield � ������� ������ StartCoroutine
    IEnumerator animation_text_ui(string stext)
    {
        int i = 0;

        //���������� end ����� ��� ����, ��� �� ������ �� ������� ���� <color>
        bool end = false;

        //���� while ������� �������� '������������ �����'
        while (i <= stext.Length)
        {
            if (i + 1 <= stext.Length)
            {
                //���� ������ ����� �� ������� '<' � ���� ���� ������ 'c' �� ������� �����
                if (stext[i] == '<' && stext[i + 1] == 'c')
                {
                    //���������� 15 ��������, ��� ����� ���� <color> ���������� ��� �������� �����
                    i += 15;

                    end = true;
                }
                //���� ������ ����� �� ������� '<' � ���� ���� ������ '/' �� ������� �����
                else if (stext[i] == '<' && stext[i + 1] == '/')
                {
                    //���������� 8 ��������, ��� ����� ���� <color> ���������� ��� �������� �����
                    i += 8;

                    end = false;
                }
            }

            //���� end = true, �� ����� ���������� � ����� </color> �� �����
            if (end)
            {
                GetComponent<Text>().text = stext.Substring(0, i) + "</color>";
            }           
            //������ �������� ����� �� �������
            else
                GetComponent<Text>().text = stext.Substring(0, i);
            
            i++;
            
            //�������� ��������� ������
            yield return new WaitForSeconds(0.05f);
        }
        //��������� ������� stop_animation_textUi()
        stop_animation_textUi();
    }

    //������� stop_animation_textUi ������������� �������� 
    void stop_animation_textUi()
    {
        //������������ ��� IEnumerator ��������
        StopAllCoroutines();
        //����� ��������� ��������, ����� ������� UI ������������ ��������� �����������
        GetComponent<Text>().text = text_ui_element;

        //���� bool finish �����
        if (!finish)
        {
            //���� bool move_Ingredients �����
            if (!move_Ingredients)
            {
                //���� bool last_station �����
                if (!last_station)
                    //�������� ������ next_station_textUi
                    next_station_textUi.SetActive(true);
                else
                {
                    //�������� ������ return_ingredients_pos, ������� ���������� ��� ����������� �� �����
                    GetComponent<return_ingredients_pos>().enabled = true;
                }
            }
            else
            {
                //�������� ������ move_Ingredients_script �� �������� ingredients_go
                ingredients_go.GetComponent<move_Ingredients_script>().enabled = true;
            }
        }
    }

    //������� next_station() ������� ������
    void next_station()
    {
        // �����������, ���� finish == false, �� ���� ���� ��� �� ��������� �����
        if (!finish)
        {
            //���� ��� ��������� ����� � ������ � ���������
            if (finish_burgers)
                //����������� ����� ����� 2
                SceneManager.LoadScene(2);
            else
            {
                //�������� ���� �����
                go_on.SetActive(true);
                //��������� ������ next_station_textUi
                next_station_textUi.SetActive(false);
                //��������� ���� ������
                gameObject.SetActive(false);
            }
        }
    }
}

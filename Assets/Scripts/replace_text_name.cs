using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //���������� ���������� ��� ������ � UI ���������� 

public class replace_text_name : MonoBehaviour
{
    //������ �������� �� ������ * �� ��� �� ����������
    //���������� �������� ������ �� ����� ������ ������ ��� ���� * � ������ ����� ��������
    void Start()
    {
        GetComponent<Text>().text = GetComponent<Text>().text.Replace("*", PlayerPrefs.GetString("Name"));
    }
}

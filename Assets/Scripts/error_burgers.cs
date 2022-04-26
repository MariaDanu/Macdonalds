using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �������� �� ����������� ����� �����������, �� ����� ������
public class error_burgers : MonoBehaviour
{
    //����� � ������� �������� ����
    float speed = 3f;
    void Update()
    {
        //���� ���� green < 1 (���� ������ �������)
        if (gameObject.GetComponent<SpriteRenderer>().color.g < 0.99f) 
            //������ ��� ����� green, blue.
            //�� �������� � ������� ������� ���� �� g/b � ���������� � speed ���������� �� Time.DeltaTime (��� ���������)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, gameObject.GetComponent<SpriteRenderer>().color.g + speed * Time.deltaTime, gameObject.GetComponent<SpriteRenderer>().color.b + speed * Time.deltaTime, 255);
        else
        {
            //order in layer ������ 3 �� ���������� Sprite Renderer
            GetComponent<SpriteRenderer>().sortingOrder = 3;
            //���� ���������� ������ ���� ����, �� �� ��������� ���� ������ �� �������, ���� �� �� ���� �������!
            GetComponent<error_burgers>().enabled = false;
        }
    }
}

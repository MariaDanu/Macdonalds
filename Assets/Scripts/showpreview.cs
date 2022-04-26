using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //���������� ���������� ��� ���������� �������

// ���� ������ �������� �� �������� ������ (mahagame)
public class showpreview : MonoBehaviour
{
    bool loads = true;
    float t;

    private void Start()
    {
        //���������� ����� � float 
        t = Time.time;
    }
    void Update()
    {
        //���� ����� ������� �� �������� � t + 2 ������� ������ ��������� �������, �� ��� ����������� 
        if (t + 2 < Time.time)
        {
            //speed - �������� ��������
            float speed = 0.5f;

            //���� loads = true
            if (loads)
            {
                //���� ������ ����������, �� ��� �����������
                if (gameObject.GetComponent<SpriteRenderer>().color.a < 0.99f)
                {
                    //������ ����� ������� �� ��������� speed ��������� �� Time.deltaTime
                    //Time.deltaTime ��� ����� ������� ������������� ��� ����������� ���������� �����. ����� ��� ���� ��� �������� ������ ������������
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a + speed * Time.deltaTime);
                }
                else
                    loads = false;
            }
            //���� loads = false
            else if (!loads)
            {
                //���� ������ �� ����������, �� ��� �����������
                if (gameObject.GetComponent<SpriteRenderer>().color.a > 0.01f)
                {
                    //������ ����� ��������� �� ��������� speed ��������� �� Time.deltaTime
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a - speed * Time.deltaTime);
                }
                else
                {
                    //���� �������� ���������, �� ����������� ����� ����� 1
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}

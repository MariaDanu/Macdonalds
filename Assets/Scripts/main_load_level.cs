using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //���������� ���������� ��� ������ �� �������


public class main_load_level : MonoBehaviour
{
    //��� ������� �������� �� �������� ����� '���������'
    public void chisburger_load_scene()
    {
        //��������� ����� ��� ������� 3
        SceneManager.LoadScene(3);
    }
    //��� ������� �������� �� �������� ����� '������� ���������'
    public void double_chisburger_load_scene()
    {
        //��������� ����� ��� ������� 4
        SceneManager.LoadScene(4);
    }
    //��� ������� �������� �� �������� ����� '���� �  ���'
    public void filet_o_fish_scene()
    {
        //��������� ����� ��� ������� 5
        SceneManager.LoadScene(5);
    }

    //��� ������� �������� �� �������� ����� '������� ���� �  ���'
    public void double_filet_o_fish_scene()
    {
        //��������� ����� ��� ������� 6
        SceneManager.LoadScene(6);
    }

    //��� ������� �������� �� ������ ����� 
    public void back_levels_menu()
    {
        //��������� ����� ��� ������� 2
        SceneManager.LoadScene(2);
    }
    //��� ������� �������� �� ������ ����
    public void back_menu()
    {
        //��������� ����� ��� ������� 1
        SceneManager.LoadScene(1);
    }
}

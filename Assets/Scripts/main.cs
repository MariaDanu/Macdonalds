using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //���������� ���������� ��� ������ �� �������
using UnityEngine.UI; //���������� ���������� ��� ������ � UI ���������� 

//���� ������ �������� �� ��� ������� � ������� ����
public class main : MonoBehaviour
{
    //������� ��������� ���������� GameObject
    //�������� ���������� ����� � ��������� ���� �������� �� �����
    public GameObject continue_btn, new_game_btn, callout, menu_text, set_name_text, start_text, noname_text, exitgame_btn;

    //void Start() ����������� ���� ��� �� ����� ������� ������� �������
    void Start()
    {
        //��������� ���������� �� ���� Name, ����������� ���� �����
        if (PlayerPrefs.HasKey("Name"))
        {
            continue_btn.GetComponent<Button>().interactable = true;
        }
    }

    //��� ������� ���������� ����� ������ "����� ����"
    public void new_game()
    {
        //��������� ������ continue_btn
        continue_btn.SetActive(false);
        //��������� ������ new_game_btn
        new_game_btn.SetActive(false);
        //��������� ������ exitgame_btn
        exitgame_btn.SetActive(false);
        //��������� ������ menu_text
        menu_text.SetActive(false);
        //�������� ������ � ������� ������� callout (��� ����� ��� ���� �����)
        callout.GetComponent<RectTransform>().anchoredPosition = new Vector2(-387.5f, 109.4f);
        callout.GetComponent<RectTransform>().sizeDelta = new Vector2(466, 327.4f);
        //�������� ������ set_name_text
        set_name_text.SetActive(true);
    }

    //��� ������� ���������� ����� ������ set_name_button (�� ����� ����� �����)
    //input_name_text ��� �������� ������ (set_name_input) ����� ������� set_name_text
    public void GetText(InputField input_name_text)
    {
        //���� ������������ �� ���� ������ 
        if (input_name_text.text == "")
        {
            //�������� ������ noname_text
            noname_text.SetActive(true);
            //��������� ��� ��� ��� (���������� ��� � ������ Name)
            PlayerPrefs.SetString("Name", ("���"));
            //�������� * �� ��� � ������ ������� start_text
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", "���");
        }
        //���� ������������ ���� ��� ��
        else
        {
            //���������� ��� ��������� ������������� � ������ NAME
            PlayerPrefs.SetString("Name", (input_name_text.text));
            //�������� * �� ��� � ������ ������� start_text
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", input_name_text.GetComponent<InputField>().text);
            //�������� ������ start_text
            start_text.SetActive(true);
        }
        //��������� ������ set_name_text
        set_name_text.gameObject.SetActive(false);
    }
    //��� ������� ���������� ����� ������ "����������"
    public void contunue_game()
    {
        //��������� ����� ��� ������� 2
        SceneManager.LoadScene(2);
    }
    //��� ������� ���������� ����� ������ exitgame
    public void ExitGame()
    {
        //������� �� ����
        Application.Quit();
    }
}

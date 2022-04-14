using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 



public class main : MonoBehaviour
{

    public GameObject continue_btn, new_game_btn, callout, menu_text, set_name_text, start_text, noname_text, continue_menu;

    void Start()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            continue_btn.GetComponent<Button>().interactable = true;
        }
    }

    
    public void new_game()
    {
        continue_btn.SetActive(false);
        new_game_btn.SetActive(false);
        menu_text.SetActive(false);
        callout.GetComponent<RectTransform>().anchoredPosition = new Vector2(-387.5f, 109.4f);
        callout.GetComponent<RectTransform>().sizeDelta = new Vector2(466, 327.4f);
        set_name_text.SetActive(true);
        

    }
    public void GetText(GameObject input_name_text)
    {
        if (input_name_text.GetComponent<InputField>().text == "")
        {
            noname_text.SetActive(true);
            PlayerPrefs.SetString("Name", ("чмо"));
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", "чмо");
        }
        else
        {
            PlayerPrefs.SetString("Name", (input_name_text.GetComponent<InputField>().text));
            start_text.GetComponent<Text>().text = start_text.GetComponent<Text>().text.Replace("*", input_name_text.GetComponent<InputField>().text);
            start_text.SetActive(true);
        }
        set_name_text.gameObject.SetActive(false);
    }
    public void contunue_game()
    {
        continue_menu.SetActive(true);
        continue_btn.SetActive(false);
        new_game_btn.SetActive(false);
        menu_text.SetActive(false);

    }
    public void chisburger_load_scene()
    {
        SceneManager.LoadScene("chisburger-scene");
    }

}

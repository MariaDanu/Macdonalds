using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 

public class move_mouse_Ingredients_script : MonoBehaviour
{
    GameObject active_go;
    public GameObject last_ingredient_go, finish_text, user_try_text, next_station_text;
    bool active_bool;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rayhit_void(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            active_bool = false;
            rayhit_void(false);
        }
        if (active_bool)
        {
            Vector2 s = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            active_go.transform.position = s;
        }
    }

    void rayhit_void(bool donw_up)
    {
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (rayHit)
        {
            if (donw_up && rayHit.transform.gameObject.tag != "Finish")
            {
                active_go = rayHit.transform.gameObject;
                active_go.GetComponent<Collider2D>().enabled = false;
                active_bool = true;
            }
            else if (!donw_up && rayHit.transform.gameObject.tag == "Finish" && active_go)
            {
                if(last_ingredient_go == active_go)
                {
                    if (active_go.GetComponent<move_Ingredients_script>().last_ingredient)
                    {
                        active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);
                        user_try_text.SetActive(false);
                        finish_text.SetActive(true);
                        next_station_text.GetComponent<Text>().text = "*что бы выйти в галвное меню нажми любую кнопку";
                        active_go.GetComponent<Collider2D>().enabled = false;
                        GetComponent<move_mouse_Ingredients_script>().enabled = false;

                    }
                    else
                    {
                        last_ingredient_go = active_go.GetComponent<move_Ingredients_script>().next_ingredient;
                        active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);
                        active_go.GetComponent<Collider2D>().enabled = false;
                        active_go = null;
                    }
                }else
                {
                    active_go.GetComponent<move_Ingredients_script>().w_moov = true;
                    active_go.GetComponent<move_Ingredients_script>().enabled = true;
                }
                
            }
        }
        else if (!donw_up && active_go)
        {
            active_go.GetComponent<move_Ingredients_script>().w_moov = true;
            active_go.GetComponent<move_Ingredients_script>().enabled = true;
        }
    }
}

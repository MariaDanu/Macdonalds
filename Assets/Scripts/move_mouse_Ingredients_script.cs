using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //Подключаем библиотеку для работы с UI элементами 

//код позволяет двигать объекты ингридиентов мышкой
public class move_mouse_Ingredients_script : MonoBehaviour
{
    GameObject active_go, active_go2;
    //active_go активный объект, которого держат мышью
    //active_go2 это копия ингредиента, активного объекта, если он есть

    public GameObject last_ingredient_go, finish_text, user_try_text, next_station_text;
    //last_ingredient_go след ингредиент, который должен идти по очереди
    //finish_text финальный слайд
    //user_try_text UI TEXT ("попробуй сам")
    //next_station_text UI TEXT ("*что бы продолжить нажми любую кнопку")

    bool active_bool;
    //держит ли пользователь мышкой объект

    int orderl = 2;
    //номер слоя (order in layer) 

    //объект mac_girl (девочка макдональдс)
    public Image mac_girl_img;
    //картинка на которую будем менять 

    public Sprite mac_girl_img_change;
    void Update()
    {
        //нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            rayhit_void(true);
        }
        // левая кнопка мыши отпущена
        if (Input.GetMouseButtonUp(0))
        {
            active_bool = false;
            rayhit_void(false);
        }
        if (active_bool)
        {
            //переменная Vector2 s (x, y) = позиции мыши 
            Vector2 s = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            //позиция объекта ингредиента равняется переменной s
            active_go.transform.position = s;
        }
    }

    //down_up 
    //если нажата левая клавиша, то down_up = true
    //если левая клавиша отпущена, то down_up = false
    void rayhit_void(bool donw_up)
    {
        //отправляется луч в позици мыши
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
        //если луч попал
        if (rayHit)
        {
            //если левая кнопка мыши нажата и если объект в которого попали тег не яляется Finish. то условие верно
            if (donw_up && rayHit.transform.gameObject.tag != "Finish")
            {
                //active_go = объекту в которого попал луч
                active_go = rayHit.transform.gameObject;
                //отключаем компонет Collider2D у active_go что бы не было никаких лишних ошибок
                active_go.GetComponent<Collider2D>().enabled = false;
                //пользователь держит мышкой объект
                active_bool = true;
                //изменяем order in layer на компонетне Sprite Renderer
                //для того, что бы объект был поверх остальных объектов
                active_go.GetComponent<SpriteRenderer>().sortingOrder = 15;
            }
            //если левая кнопка мыши отпущена и если объект в которого попал луч тег яляется Finish. то условие верно
            else if (!donw_up && rayHit.transform.gameObject.tag == "Finish" && active_go)
            {
                //проверяем является ли объект правильным по последовательности или его идентичный объект
                if(last_ingredient_go == active_go || last_ingredient_go == active_go.GetComponent<move_Ingredients_script>().same_go)
                {
                    //если объект последний (bool last_ingredient = true)
                    if (active_go.GetComponent<move_Ingredients_script>().last_ingredient)
                    {
                        //меняем картинку mac_girl
                        mac_girl_img.sprite = mac_girl_img_change;
                        //позиция active_go равна объекту с тегом finish, но позиция по y равна заранее записанному в move_Ingredients_script у объекта
                        active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);
                        //выключаем текст user_try_text
                        user_try_text.SetActive(false);
                        //включаем finish_text
                        finish_text.SetActive(true);
                        //изменяем текст на объекте next_station_text
                        next_station_text.GetComponent<Text>().text = "*что бы выйти в галвное меню нажми любую кнопку";
                        //отключаем компонет Collider2D у active_go что бы не было никаких лишних ошибок
                        active_go.GetComponent<Collider2D>().enabled = false;
                        //отключаем компонет move_mouse_Ingredients_script у этого объекта к которому привязан этот скрипт
                        GetComponent<move_mouse_Ingredients_script>().enabled = false;
                    }
                    else
                    {
                        //добавляем к order in layer + 1 на компонетне Sprite Renderer
                        //для того, что бы объект был поверх остальных объектов
                        //и делаем мы это с помощью orderl, что бы ингредиенты бургера были последовательны 
                        orderl += 1;
                        active_go.GetComponent<SpriteRenderer>().sortingOrder = orderl;

                        //если объект который должен идти по последовательности = идентичному активного объекта, то условие верно
                        if (last_ingredient_go == active_go.GetComponent<move_Ingredients_script>().same_go)
                        {
                            //в active_go2 мы записываем индентичны объект active_go.same_go 
                            active_go2 = active_go.GetComponent<move_Ingredients_script>().same_go;
                            //следующим объектом последовательности становитсья active_go2.next_ingredient
                            last_ingredient_go = active_go2.GetComponent<move_Ingredients_script>().next_ingredient;
                            //позиция active_go равна объекту с тегом finish, но позиция по y равна заранее записанному в move_Ingredients_script у объекта
                            active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go2.GetComponent<move_Ingredients_script>().y_pos, 0);
                        }
                        else
                        {
                            //следующим объектом последовательности становитсья active_go.next_ingredient
                            last_ingredient_go = active_go.GetComponent<move_Ingredients_script>().next_ingredient;
                            //позиция active_go равна объекту с тегом finish, но позиция по y равна заранее записанному в move_Ingredients_script у объекта
                            active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);


                        }
                        //отключаем компонет Collider2D у active_go что бы не было никаких лишних ошибок
                        active_go.GetComponent<Collider2D>().enabled = false;
                        //делаем переменную active_go пустой, что бы не было никак ошибок
                        active_go = null;
                    }
                }
                //если объект был не верным по последовательности 
                else
                {
                    // цвет active_go делаем красным
                    active_go.GetComponent<SpriteRenderer>().color = Color.red;
                    //включаем скрипт error_burgers на объекте active_go
                    active_go.GetComponent<error_burgers>().enabled = true;
               
                    //bool w_moov ставим true в скрипте move_Ingredients_script
                    active_go.GetComponent<move_Ingredients_script>().w_moov = true;
                    //вкоючаем скрипт move_Ingredients_script на объекте active_go
                    active_go.GetComponent<move_Ingredients_script>().enabled = true;
                }
                
            }
            //исключаем ошибки 
            //если объект отпустили и тег равен Untagged и при этом active_go держали мышью
            else if (!donw_up && rayHit.transform.gameObject.tag == "Untagged" && active_go)
            {
                //order in layer ставим 3 на компонетне Sprite Renderer
                active_go.GetComponent<SpriteRenderer>().sortingOrder = 3;
                //bool w_moov ставим true в скрипте move_Ingredients_script
                active_go.GetComponent<move_Ingredients_script>().w_moov = true;
                //вкоючаем скрипт move_Ingredients_script на объекте active_go
                active_go.GetComponent<move_Ingredients_script>().enabled = true;
            }

        }
        //если объект отпустили и при этом active_go держали мышью
        else if (!donw_up && active_go)
        {
            //order in layer ставим 3 на компонетне Sprite Renderer
            active_go.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //bool w_moov ставим true в скрипте move_Ingredients_script
            active_go.GetComponent<move_Ingredients_script>().w_moov = true;
            //вкоючаем скрипт move_Ingredients_script на объекте active_go
            active_go.GetComponent<move_Ingredients_script>().enabled = true;
        }
    }
}

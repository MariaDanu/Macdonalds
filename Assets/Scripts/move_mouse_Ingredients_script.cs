using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //���������� ���������� ��� ������ � UI ���������� 

//��� ��������� ������� ������� ������������ ������
public class move_mouse_Ingredients_script : MonoBehaviour
{
    GameObject active_go, active_go2;
    //active_go �������� ������, �������� ������ �����
    //active_go2 ��� ����� �����������, ��������� �������, ���� �� ����

    public GameObject last_ingredient_go, finish_text, user_try_text, next_station_text;
    //last_ingredient_go ���� ����������, ������� ������ ���� �� �������
    //finish_text ��������� �����
    //user_try_text UI TEXT ("�������� ���")
    //next_station_text UI TEXT ("*��� �� ���������� ����� ����� ������")

    bool active_bool;
    //������ �� ������������ ������ ������

    int orderl = 2;
    //����� ���� (order in layer) 

    //������ mac_girl (������� �����������)
    public Image mac_girl_img;
    //�������� �� ������� ����� ������ 

    public Sprite mac_girl_img_change;
    void Update()
    {
        //������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            rayhit_void(true);
        }
        // ����� ������ ���� ��������
        if (Input.GetMouseButtonUp(0))
        {
            active_bool = false;
            rayhit_void(false);
        }
        if (active_bool)
        {
            //���������� Vector2 s (x, y) = ������� ���� 
            Vector2 s = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            //������� ������� ����������� ��������� ���������� s
            active_go.transform.position = s;
        }
    }

    //down_up 
    //���� ������ ����� �������, �� down_up = true
    //���� ����� ������� ��������, �� down_up = false
    void rayhit_void(bool donw_up)
    {
        //������������ ��� � ������ ����
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
        //���� ��� �����
        if (rayHit)
        {
            //���� ����� ������ ���� ������ � ���� ������ � �������� ������ ��� �� ������� Finish. �� ������� �����
            if (donw_up && rayHit.transform.gameObject.tag != "Finish")
            {
                //active_go = ������� � �������� ����� ���
                active_go = rayHit.transform.gameObject;
                //��������� �������� Collider2D � active_go ��� �� �� ���� ������� ������ ������
                active_go.GetComponent<Collider2D>().enabled = false;
                //������������ ������ ������ ������
                active_bool = true;
                //�������� order in layer �� ���������� Sprite Renderer
                //��� ����, ��� �� ������ ��� ������ ��������� ��������
                active_go.GetComponent<SpriteRenderer>().sortingOrder = 15;
            }
            //���� ����� ������ ���� �������� � ���� ������ � �������� ����� ��� ��� ������� Finish. �� ������� �����
            else if (!donw_up && rayHit.transform.gameObject.tag == "Finish" && active_go)
            {
                //��������� �������� �� ������ ���������� �� ������������������ ��� ��� ���������� ������
                if(last_ingredient_go == active_go || last_ingredient_go == active_go.GetComponent<move_Ingredients_script>().same_go)
                {
                    //���� ������ ��������� (bool last_ingredient = true)
                    if (active_go.GetComponent<move_Ingredients_script>().last_ingredient)
                    {
                        //������ �������� mac_girl
                        mac_girl_img.sprite = mac_girl_img_change;
                        //������� active_go ����� ������� � ����� finish, �� ������� �� y ����� ������� ����������� � move_Ingredients_script � �������
                        active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);
                        //��������� ����� user_try_text
                        user_try_text.SetActive(false);
                        //�������� finish_text
                        finish_text.SetActive(true);
                        //�������� ����� �� ������� next_station_text
                        next_station_text.GetComponent<Text>().text = "*��� �� ����� � ������� ���� ����� ����� ������";
                        //��������� �������� Collider2D � active_go ��� �� �� ���� ������� ������ ������
                        active_go.GetComponent<Collider2D>().enabled = false;
                        //��������� �������� move_mouse_Ingredients_script � ����� ������� � �������� �������� ���� ������
                        GetComponent<move_mouse_Ingredients_script>().enabled = false;
                    }
                    else
                    {
                        //��������� � order in layer + 1 �� ���������� Sprite Renderer
                        //��� ����, ��� �� ������ ��� ������ ��������� ��������
                        //� ������ �� ��� � ������� orderl, ��� �� ����������� ������� ���� ��������������� 
                        orderl += 1;
                        active_go.GetComponent<SpriteRenderer>().sortingOrder = orderl;

                        //���� ������ ������� ������ ���� �� ������������������ = ����������� ��������� �������, �� ������� �����
                        if (last_ingredient_go == active_go.GetComponent<move_Ingredients_script>().same_go)
                        {
                            //� active_go2 �� ���������� ���������� ������ active_go.same_go 
                            active_go2 = active_go.GetComponent<move_Ingredients_script>().same_go;
                            //��������� �������� ������������������ ����������� active_go2.next_ingredient
                            last_ingredient_go = active_go2.GetComponent<move_Ingredients_script>().next_ingredient;
                            //������� active_go ����� ������� � ����� finish, �� ������� �� y ����� ������� ����������� � move_Ingredients_script � �������
                            active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go2.GetComponent<move_Ingredients_script>().y_pos, 0);
                        }
                        else
                        {
                            //��������� �������� ������������������ ����������� active_go.next_ingredient
                            last_ingredient_go = active_go.GetComponent<move_Ingredients_script>().next_ingredient;
                            //������� active_go ����� ������� � ����� finish, �� ������� �� y ����� ������� ����������� � move_Ingredients_script � �������
                            active_go.transform.position = new Vector3(rayHit.transform.position.x, active_go.GetComponent<move_Ingredients_script>().y_pos, 0);


                        }
                        //��������� �������� Collider2D � active_go ��� �� �� ���� ������� ������ ������
                        active_go.GetComponent<Collider2D>().enabled = false;
                        //������ ���������� active_go ������, ��� �� �� ���� ����� ������
                        active_go = null;
                    }
                }
                //���� ������ ��� �� ������ �� ������������������ 
                else
                {
                    // ���� active_go ������ �������
                    active_go.GetComponent<SpriteRenderer>().color = Color.red;
                    //�������� ������ error_burgers �� ������� active_go
                    active_go.GetComponent<error_burgers>().enabled = true;
               
                    //bool w_moov ������ true � ������� move_Ingredients_script
                    active_go.GetComponent<move_Ingredients_script>().w_moov = true;
                    //�������� ������ move_Ingredients_script �� ������� active_go
                    active_go.GetComponent<move_Ingredients_script>().enabled = true;
                }
                
            }
            //��������� ������ 
            //���� ������ ��������� � ��� ����� Untagged � ��� ���� active_go ������� �����
            else if (!donw_up && rayHit.transform.gameObject.tag == "Untagged" && active_go)
            {
                //order in layer ������ 3 �� ���������� Sprite Renderer
                active_go.GetComponent<SpriteRenderer>().sortingOrder = 3;
                //bool w_moov ������ true � ������� move_Ingredients_script
                active_go.GetComponent<move_Ingredients_script>().w_moov = true;
                //�������� ������ move_Ingredients_script �� ������� active_go
                active_go.GetComponent<move_Ingredients_script>().enabled = true;
            }

        }
        //���� ������ ��������� � ��� ���� active_go ������� �����
        else if (!donw_up && active_go)
        {
            //order in layer ������ 3 �� ���������� Sprite Renderer
            active_go.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //bool w_moov ������ true � ������� move_Ingredients_script
            active_go.GetComponent<move_Ingredients_script>().w_moov = true;
            //�������� ������ move_Ingredients_script �� ������� active_go
            active_go.GetComponent<move_Ingredients_script>().enabled = true;
        }
    }
}

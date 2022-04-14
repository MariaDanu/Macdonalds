using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Ingredients_script : MonoBehaviour
{
    public GameObject move_to_go, next_station_text, cam, next_ingredient;
    public float y_pos;
    public bool w_moov, last_ingredient;
    private Vector3 pos, move_to_vector3;

    void Start()
    {
        pos = transform.position;
        move_to_vector3 = new Vector3(move_to_go.transform.position.x, y_pos, 0);
        GetComponent<move_Ingredients_script>().enabled = false;
    }

    void Update()
    {
        if (!w_moov)
        {
            if (transform.position.x != move_to_vector3.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, move_to_vector3, 15 * Time.deltaTime);
            }
            else
            {
                next_station_text.SetActive(true);
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }
        else if (w_moov)
        {
            if (transform.position != pos)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, 15 * Time.deltaTime);
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
                cam.GetComponent<move_mouse_Ingredients_script>().enabled = true;
                GetComponent<move_Ingredients_script>().enabled = false;
            }
        }


    }

}

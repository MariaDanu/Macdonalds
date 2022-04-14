using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showpreview : MonoBehaviour
{
    bool loads = true;
    public GameObject cam, macgirl, btn_con, btn_ng;
    float t;
    private void Start()
    {
        cam.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 0);
        t = Time.time;
    }
    void Update()
    {
        if (!(t + 2 > Time.time))
        {
            float speed = 0.5f;
            if (loads)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color.a < 0.99f)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a + speed * Time.deltaTime);
                }
                else
                    loads = false;
            }
            else if (!loads)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color.a > 0.01f)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, gameObject.GetComponent<SpriteRenderer>().color.a - speed * Time.deltaTime);
                }
                else
                {
                    cam.GetComponent<Camera>().backgroundColor = new Color32(0, 255, 255, 0);
                    macgirl.SetActive(true);
                    btn_con.SetActive(true);
                    btn_ng.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_text_script : MonoBehaviour
{
    void Start()
    {
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(-175.1f, 186.7f);
        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(301.2f, 177.51f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//библиотека событый

public class OnOffelements : MonoBehaviour
{
    public GameObject off_go, on_go;
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.inputString != "" || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            on_go.SetActive(true);
            off_go.SetActive(false);

        }

    }
    
}

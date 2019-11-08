using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    bool active;
    Canvas Canvas;
    void Start()
    {
        Canvas = GetComponent<Canvas>();
        Canvas.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            Canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
    }
}

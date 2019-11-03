using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{
    public float speed;
    Vector2 fondopos;
    void Start()
    {

    }

    void Moverfondo()
    {
        fondopos = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = fondopos;
    }
    void Update()
    {
        Moverfondo();
    }
   
}

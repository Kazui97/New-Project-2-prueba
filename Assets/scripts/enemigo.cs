using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    Vector3 pos = new Vector3 (0,0,0);
    int mov = 20;
    int m;
    void Start()
    {
        m = Random.Range(0,1);
        
    }


    public void Moverenemigo()
    {
        transform.position -= transform.right = pos;
    }

    void Update()
    {
        
        if (gameObject.transform.position.y >= 75)
        {
            gameObject.transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
        }
        if (gameObject.transform.position.x <= 75)
        {
            mov *= 1;
            if (gameObject.transform.position.x <= -75)
            {
                mov *= -1;
            }
        }
        else
        {
            mov *= -1;
        }
        gameObject.transform.position -= new Vector3(mov * Time.deltaTime, 0, 0);
        
    }
}

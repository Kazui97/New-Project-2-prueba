using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiles : MonoBehaviour
{
    int caida = 30;
    void Start()
    {
        
    }
    

    void Caer()
    {
        gameObject.transform.position -= new Vector3(0, caida * Time.deltaTime, 0);

        if(gameObject.transform.position.y <= -80)
        {
            gameObject.transform.position = new Vector3(Random.Range(-75, 75), 100, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Caer();
    }
}

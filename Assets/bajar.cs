using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bajar : MonoBehaviour
{
   public float velocidad;

  
    void Start()
    {
        velocidad = Random.Range(1.5f,3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3( 0, 0,velocidad* Time.deltaTime);
    }
}

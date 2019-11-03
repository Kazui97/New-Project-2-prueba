using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
        void Start()
        {
        
        }

    public void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.GetComponent<enemigo>() && col.gameObject.GetComponent<enemigo2>())
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.position += new Vector3(0, 10, 0);
        
    }
}

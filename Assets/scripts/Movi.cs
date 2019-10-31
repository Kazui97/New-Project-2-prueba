using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movi : MonoBehaviour
{
    public float vel = 20;
    public GameObject bala;

    void Start()
    {
       
    }

   
    public void Movimiento()
    {
        if ( Input.GetKey(KeyCode.W))
        {
           
            transform.position+= transform.right * vel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position-= transform.right * vel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
             transform.position -= transform.up * vel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
             transform.position += transform.up * vel * Time.deltaTime;
        }
       // if (Input.GetKey(KeyCode.Space))
        //{
          //   transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 100, Time.deltaTime));
        //}
    }
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bala = Instantiate(bala, gameObject.transform);
            bala.transform.position = gameObject.transform.position;
            bala.transform.parent = null;
            bala.name = "bala";
        }
        //bala.transform.position += new Vector3(0, 10, 0);
        
        Movimiento();
    }
}

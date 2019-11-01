using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movi : MonoBehaviour
{
    public float vel = 20;
    public GameObject bala;
    public GameObject canon;
    GameObject balas;

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 100, Time.deltaTime));
        }
    }
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            balas = Instantiate(bala , canon.GetComponent<Transform>().position,Quaternion.identity);
//            balas.AddComponent<Rigidbody>().AddForce(transform.up*2000);
            balas.transform.parent = null;
            balas.name = "balas";
            Destroy(balas, 1.5f);



           // bala = Instantiate(bala, gameObject.transform);   //-------------------------- forma que no borra balas :,v --------------------------- \\
            // bala.transform.position = gameObject.transform.position;
           // bala.transform.parent = null;
           // bala.name = "bala";
            //Destroy(bala,1.5f);
        }
        //bala.transform.position += new Vector3(0, 10, 0);
        
        
           
          
        
        Movimiento();
    }
}

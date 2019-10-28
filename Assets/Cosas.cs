using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosas : MonoBehaviour
{
    public GameObject carrito;
    public Material rojo;
    public Material azul;
    public Material amarillo;
    public float limit1 = 2.16f;
    


    void Akawe()
    {
        
     }
    void Start()
    {
       
    }

   /*  public static void shufflet(List<colores>List)
    {
        int n = List.Count;

        while(n>1)
        {
            n--;
            int k = Random.Range(0,n+1);
            colores value = List[k];
            List [k]  = List[n];
            List [n]  = value;
        }
    }*/
    void Update()
    {
        if (Input.GetKeyUp("a")) transform.position -= transform.right = new Vector3(1,0,0);
        if (Input.GetKeyUp("d")) transform.position += transform.right = new Vector3(1,0,0);
        
        if(transform.position.x > 11)
        {
            
        }
    }
    
    public enum colores
    {
        rojo,
        azul,
        amarillo
    }
    public colores colors;
}

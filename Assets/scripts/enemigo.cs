using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    Vector3 pos = new Vector3 (0,0,0);
    int mov = 15;
    int m;
    int movVert = -20;
    float vida = 100;
    

    void Start()
    {
        m = Random.Range(0,2);
        Invoke("LLamaCorru", 2.5f);
    }

    void LLamaCorru()
    {
        StartCoroutine("nelly");
    }

    
    IEnumerator nelly()
    {
        while (true)
        {
            movVert *= -1;
            yield return new WaitForSeconds(1.5f);
        }
    }


    public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<bala>())
            {   
                vida -= 10;
                
                if (vida == 0)
                {
                    StopCoroutine("nelly");
                    gameObject.transform.position = new Vector3 (Random.Range(-75,75), 100, 0);
                    movVert = -20;
                    vida = 100; 
                    if (true)
                    {
                        Invoke("LLamaCorru", 2.5f);
                    }
                    
                   // gameObject.transform.position += new Vector3(0, movVert + -20 * Time.deltaTime , 0);
                   // Destroy(gameObject);
                   // Debug.Log ("exploto :v");
                }
                Debug.Log(vida);
                
                
            }
        }
    public void Moverenemigo()
    {

    }
    public void MovimientoEnemigo()
    {
        gameObject.transform.position += new Vector3(0, movVert * Time.deltaTime, 0);

        if (gameObject.transform.position.x <= 75)
        {
            if (gameObject.transform.position.x <= -75)
            {
                mov *= -1;
            }
        }
        else
        {
            mov *= -1;
        }
        if (m == 0)
        {
            gameObject.transform.position += new Vector3(mov * Time.deltaTime, 0, 0); 
        }
        else
        {
            gameObject.transform.position -= new Vector3(mov * Time.deltaTime, 0, 0);
        }
        if (vida <= 25)
        {
            movVert = -50;
            gameObject.transform.position += new Vector3 ( 0, movVert* Time.deltaTime,0);
        }
        if (gameObject.transform.position.y <= -110)
        {
            gameObject.transform.position = new Vector3 (Random.Range(-75,75), 100, 0);
           
        }
    }
    void Update()
    {
        
        MovimientoEnemigo();

    }
}

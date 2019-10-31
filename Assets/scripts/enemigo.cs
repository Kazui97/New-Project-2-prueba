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

    void Vida()
    {
        
        if ()
        {
            
        }
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
                if (vida == 0)
                {
                    Destroy(gameObject);
                }
                Debug.Log ("di puto");
                
                
            }
        }
    public void Moverenemigo()
    {
       if ( m == 0)
       {
            if (gameObject.transform.position.y >= 75)
            {
                gameObject.transform.position -= new Vector3(0, 10 * Time.deltaTime, 0);
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
       else if (m == 1)
        {
            if (gameObject.transform.position.y <= 75)
            {
                gameObject.transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
            }
            if (gameObject.transform.position.x >= 75)
            {
                mov *= -1;
                if (gameObject.transform.position.x >= -75)
                {
                    mov *= 1;
                }
            }
            else
            {
                mov *= 1;
            }
            gameObject.transform.position += new Vector3(mov * Time.deltaTime, 0, 0);

        }


    }

    void Update()
    {
        int temp =(int) Time.timeSinceLevelLoad;
        if (temp >= 90)
        {

        }
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
        

    }
}

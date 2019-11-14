using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
   
    int mov = 15;
    int m;
    int movVert = -20;
    int vidasreset = 5;
    float vida = 100;
    public GameObject bala;
    public GameObject canon;
    GameObject balasenemigas;
    public ParticleSystem humo;
    public AudioClip balaE;
    public ParticleSystem explocion;
    AudioSource balaenemigo;

    private void Awake()
    {
     
    }
    void Start()
    {
       
        m = Random.Range(0,2);
        Invoke("LLamaCorru", 2.5f);
        balaenemigo = GetComponent<AudioSource>();
        InvokeRepeating("DisparoEnemigo", 1f, 1f);

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
                
                if(vida == 0)
                {
                    explocion.Stop();
                    humo.Stop();
                    vidasreset --;
                    if (vidasreset == 0)
                    {
                        Destroy(this.gameObject);
                    }

                    Invoke("Reaparece", 0.5f);
                }
                
            }
            
                
               
        }
        if (col.gameObject.GetComponent<misillll>())
        {   
            vida -= 20;
                
            if (vida == 0)
            {
                
                if(vida == 0)
                {
                    explocion.Stop();
                    humo.Stop();
                    vidasreset --;
                    if (vidasreset == 0)
                    {
                        Destroy(this.gameObject);
                    }

                    Invoke("Reaparece", 0.5f);
                }
                
            }
            
                
               
        }
    }


    void Reaparece()
    {
        StopCoroutine("nelly");
        gameObject.transform.position = new Vector3 (Random.Range(-75,75), 100, 0);
        movVert = -20;
        humo.Stop();
        explocion.Stop();
        vida = 100;
        if (true)
        {
            Invoke("LLamaCorru", 2.5f);
        }
    }
    

    public void DisparoEnemigo()
    {
        balasenemigas = Instantiate(bala, canon.GetComponent<Transform>().position, Quaternion.identity);
        balasenemigas.transform.parent = null;
        balaenemigo.PlayOneShot(balaE);
        balasenemigas.name = "balasenemigas";
        Destroy(balasenemigas, 1.5f);
    }
    public void MovimientoEnemigo()
    {
        gameObject.transform.position += new Vector3(0, movVert * Time.deltaTime, 0);

        if (gameObject.transform.position.x <= 120)
        {
            if (gameObject.transform.position.x <= -120)
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
        if (vida <= 50)
        {
            humo.Play();
        }
        if (vida <= 25)
        {
            movVert = -50;
            gameObject.transform.position += new Vector3 ( 0, movVert* Time.deltaTime,0);
        }
        if (vida == 0)
        {
            explocion.Play();
        }
        if (gameObject.transform.position.y <= -110)
        {
            gameObject.transform.position = new Vector3 (Random.Range(-75,75), 100, 0);
           
        }

    }
    void Update()
    {
        
        MovimientoEnemigo();
         //DisparoEnemigo() ;
       
    }

    
}

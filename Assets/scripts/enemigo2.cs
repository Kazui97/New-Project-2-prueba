using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo2 : MonoBehaviour
{
    Vector3 pos = new Vector3(0, 0, 0);
    int mov = 15;
    int m;
    int movVert = -20;
    int temp;
    int vidarestantes = 3;
    float vida = 300;
    public GameObject bala;
    public GameObject canon1;
    public AudioClip sonibala;
    GameObject balasenemigas;
    public ParticleSystem explocion;
    

    AudioSource sonib;
    void Start()
    {
        sonib = GetComponent<AudioSource>();
        m = Random.Range(0, 2);
        Invoke("LLamaCorru", 35);
        Invoke("LlamadoTiro", 30);
    }

    void LLamaCorru()
    {
        StartCoroutine("nelly");
    }
    void LlamadoTiro()
    {
        InvokeRepeating("DisparoEnenmigo", 1f, 1f);
    }
    IEnumerator nelly()
    {
        while (true)
        {
            movVert *= -1;
            yield return new WaitForSeconds(2.5f);
        }
    }


     public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<bala>())
        {
            vida -= 10;

            if (vida == 0)
            {
                if (vida == 0)
                {
                    
                    vidarestantes--;
                    if (vidarestantes == 0)
                    {
                        explocion.Play();
                        Invoke("explodestru", 1);
                    }

                }
                Invoke("Reaparece", 1);
            }
           


        }
        if (col.gameObject.GetComponent<misillll>())
        {
            vida -= 20;

            if (vida == 0)
            {
                if (vida == 0)
                {
                    
                    vidarestantes--;
                    if (vidarestantes == 0)
                    {
                        explocion.Play();
                        Invoke("explodestru", 1);
                    }

                }
                Invoke("Reaparece", 1);
            }
           


        }
    }

    void explodestru()
    {
        Destroy(this.gameObject);
    }
    void Reaparece()
    {
        StopCoroutine("nelly");
        gameObject.transform.position = new Vector3(Random.Range(-75, 75), 106, 0);
        movVert = -35;
        explocion.Stop();
        vida = 100;
        if (true)
        {
            Invoke("LLamaCorru", 3.5f);
        }
    }
    void DisparoEnenmigo()
    {
        balasenemigas = Instantiate(bala, canon1.GetComponent<Transform>().position, Quaternion.identity);
        balasenemigas.transform.parent = null;
        sonib.PlayOneShot(sonibala);
        balasenemigas.name = "balasEnemigas2";
        Destroy(balasenemigas, 1.5f);
    }
    public void Moverenemigo()
    {
        temp = (int)Time.timeSinceLevelLoad;
        if (temp >= 30)
        {
            gameObject.transform.position += new Vector3(0, movVert * Time.deltaTime, 0);
            

            if (gameObject.transform.position.x <= 100)
            {
                if (gameObject.transform.position.x <= -100)
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
            if(vida == 0)
            {
                explocion.Play();
                
            }
           
        }


    }
   
    void Update()
    {
       
        Moverenemigo();
        

    }
}

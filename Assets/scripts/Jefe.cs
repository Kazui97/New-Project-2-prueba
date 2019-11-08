using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jefe : MonoBehaviour
{ 
    int mov = 20;
    int m;
    int movVert = -30;
    int temp;
    //int vidarestantes = 3;
    float vida = 700;
    public GameObject municion1;
    public GameObject municion2;
    public GameObject municion3;
    public GameObject municion4;
    public GameObject canon1;
    public GameObject canon2;
    public GameObject canon3;
    public GameObject canon4;
    GameObject bala1;
    GameObject bala2;
    GameObject bala3;
    GameObject bala4;
    public ParticleSystem explocion;
    public AudioClip sonidobala;
    AudioSource balasonido;

    void Start()
    {
        balasonido = GetComponent<AudioSource>();
        m = Random.Range(0, 2);
        Invoke("LLamaCorru", 65);
        Invoke("LlamadoTiro", 60);
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
                explocion.Play();
                Invoke("ExploDestruir", 1);
                
                if (vida == 0)
                    Escenafinal();
            }
           


        }
     }
    void ExploDestruir()
    {
        Destroy(this.gameObject);
       
    }
    void Escenafinal()
    {
        if (vida == 0)
            SceneManager.LoadScene("finperdio");
       
    }
    void DisparoEnenmigo()
    {
        bala1 = Instantiate(municion1, canon1.GetComponent<Transform>().position, Quaternion.identity);
        bala1.transform.parent = null;
        balasonido.PlayOneShot(sonidobala);
        bala1.transform.eulerAngles = new Vector3(180,0,0);
        bala1.name = "balasEnemigas2";
        Destroy(bala1, 1.5f);
        bala2 = Instantiate(municion2, canon2.GetComponent<Transform>().position, Quaternion.identity);
        bala2.transform.parent = null;
        balasonido.PlayOneShot(sonidobala);
        bala2.transform.eulerAngles = new Vector3(180,0,0);
        bala2.name = "balasEnemigas2";
        Destroy(bala2, 1.5f);
        bala3 = Instantiate(municion3, canon3.GetComponent<Transform>().position, Quaternion.identity);
        bala3.transform.parent = null;
        balasonido.PlayOneShot(sonidobala);
        bala3.transform.eulerAngles = new Vector3(180,0,0);
        bala3.name = "balasEnemigas2";
        Destroy(bala3, 1.5f);
        bala4 = Instantiate(municion4, canon4.GetComponent<Transform>().position, Quaternion.identity);
        bala4.transform.parent = null;
        balasonido.PlayOneShot(sonidobala);
        bala4.transform.eulerAngles = new Vector3(180,0,0);
        bala4.name = "balasEnemigas2";
        Destroy(bala4, 1.5f);
    }
    public void Moverenemigo()
    {
        temp = (int)Time.timeSinceLevelLoad;
        if (temp >= 60)
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

        }


    }
   
    void Update()
    {
       
        Moverenemigo();
       

    }

}

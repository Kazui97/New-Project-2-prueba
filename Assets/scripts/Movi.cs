using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movi : MonoBehaviour
{
    public float vel = 30;
    public GameObject bala;
    public GameObject canon;
    GameObject balas;
    public AudioClip sonidobala;
    public ParticleSystem escudo;
    public ParticleSystem chispas;
    public ParticleSystem explo;
    public Text vida;
    int vidasrestantes = 100;
    public bool puedehacerdaño = true;

    AudioSource audiobala;
    private void Awake()
    {
        audiobala = GetComponent<AudioSource>();
    }

    void Start()
    {
        vida.text = "vidas:  " + vidasrestantes;
        
    }
    public void OnCollisionEnter(Collision col)
    {
        if (!puedehacerdaño)
        return;
        if (col.gameObject.GetComponent<misiles>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if(col.gameObject.GetComponent<enemigo>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if(col.gameObject.GetComponent<enemigo2>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if (col.gameObject.GetComponent<Jefe>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if (col.gameObject.GetComponent<balajefe>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if(col.gameObject.GetComponent<balaenemiga>())
        {
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
       
       // Destroy(this.gameObject);
    }
    void vidacero()
    {
        if (vidasrestantes == 0)
        {
            explo.Play();
            Invoke("destruir", 1);
        }
    }
    void destruir()
    {
        Destroy(this.gameObject);
    }
    void ActivarDaño()
    {
        puedehacerdaño = true;
        escudo.Stop();
    }
    void ActualizardorUI()
    {
         if (vidasrestantes < 0)
        {
            vidasrestantes = 0;
        }
        vida.text = "vidas:  " + vidasrestantes;
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
        if (gameObject.transform.position.y <= -74f)
        {
            explo.Play();
            Invoke("destruir", 1);

        }
        if (gameObject.transform.position.x <= -147f)
        {
            explo.Play();
            Invoke("destruir", 1);
        }
        if(gameObject.transform.position.x >= 147f)
        {
            explo.Play();
            Invoke("destruir", 1);
        }
    }
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audiobala.PlayOneShot(sonidobala);
            chispas.Play();
            balas = Instantiate(bala , canon.GetComponent<Transform>().position,Quaternion.identity);
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

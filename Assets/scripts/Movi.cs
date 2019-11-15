using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movi : MonoBehaviour
{
    public float vel;
    public GameObject mil;
    public GameObject bala;
    public GameObject canon;
    public GameObject canon2;
    GameObject balas;
    GameObject misil;
    public AudioClip sonidobala;
    public AudioClip sonidomisil;
    public ParticleSystem escudo;
    public ParticleSystem chispas;
    public ParticleSystem explo;
    public Text vida;
    int vidasrestantes = 5;
    public bool puedehacerdaño = true;
    public FixedJoystick joystick;
    


    AudioSource audiobala;
    AudioSource misilaudio;
    private void Awake()
    {
        audiobala = GetComponent<AudioSource>();
        misilaudio = GetComponent<AudioSource>();
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
            Invoke("Destruir", 1);
            Invoke("Finjuego", 1f);
           // Time.timeScale = 0; // para juego
        }
    }

    void Finjuego()
    {
        if(vidasrestantes  == 0)
        SceneManager.LoadScene("fingano");
    }
   
    void Destruir()
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

        Vector2 joystickdirec = joystick.Direction * vel *Time.deltaTime;
        transform.position += new Vector3(joystickdirec.x,0,0);
        transform.position -= new Vector3(0,joystickdirec.y,0);


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
            
            if (!puedehacerdaño)
        return;
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();

        }
        if (gameObject.transform.position.x <= -147f)
        {
             if (!puedehacerdaño)
        return;
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
        if(gameObject.transform.position.x >= 147f)
        {
              if (!puedehacerdaño)
        return;
            escudo.Play();
            puedehacerdaño = false;
            Invoke("ActivarDaño",3);
            vidasrestantes--;
            ActualizardorUI();
            vidacero();
        }
    }
    
   
    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparot();
        } 
        if (Input.GetKeyDown(KeyCode.F))
        {
            Misil();
        }
        Movimiento();
    }
    public void disparot()
    {
        audiobala.PlayOneShot(sonidobala);
            chispas.Play();
            balas = Instantiate(bala , canon.GetComponent<Transform>().position,Quaternion.identity);
            balas.transform.parent = null;
            balas.name = "balas";
            Destroy(balas, 1.5f);
    }
    public void Misil()
    {
        misilaudio.PlayOneShot(sonidomisil);
        chispas.Play();
        misil = Instantiate(mil , canon2.GetComponent<Transform>().position,Quaternion.identity);
        misil.transform.parent = null;
        misil.name = "misil";
        Destroy(misil,1);
    }
}

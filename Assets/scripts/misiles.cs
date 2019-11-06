using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiles : MonoBehaviour
{
    int caida = 30;
    int vidasrestantes = 5;
    public AudioClip expl;
    public ParticleSystem explocion;
    AudioSource audioexplo;

    void Awake()
    {
        
    }
    void Start()
    {
       audioexplo = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Movi>())
        {
            
            explocion.Play();
            Sonido();
           Invoke("PruebaReaparece",3);
           

            if(vidasrestantes == 0)
            {
                Invoke("Explo", 1);
            }


           
            
        }
    }
    void PruebaReaparece()
    {
         explocion.Stop();
        gameObject.transform.position = new Vector3 (Random.Range(-100,100), 150,0);
        
            
    }
    void Sonido()
    {
        audioexplo.PlayOneShot(expl);
    }
    void Explo()
    {
        Destroy(this.gameObject);
    }
    void Caer()
    {
        gameObject.transform.position -= new Vector3(0, caida * Time.deltaTime, 0);

            if(gameObject.transform.position.y <= -80)
            {
                //gameObject.transform.position = new Vector3(Random.Range(-75, 75), 100, 0);
                gameObject.transform.position = new Vector3 (Random.Range(-100,100), 150,0);
            }   
    }

    // Update is called once per frame
    void Update()
    {
        Caer();
    }
}

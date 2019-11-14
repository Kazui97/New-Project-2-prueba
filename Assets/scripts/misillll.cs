using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misillll : MonoBehaviour
{
     public ParticleSystem exp;
    public AudioClip sonido;
    AudioSource s;
    void Start()
    {
        s = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision col)
    {
         if (col.gameObject.GetComponent<enemigo>())
        {
           
            exp.Play();
            s.PlayOneShot(sonido);
            Invoke("Destruir",1);
            
        }
        if (col.gameObject.GetComponent<enemigo2>())
        {
            exp.Play();
            s.PlayOneShot(sonido);
            Invoke("Destruir",1);
        }
          if (col.gameObject.GetComponent<Jefe>())
        {
            exp.Play();
            s.PlayOneShot(sonido);
            Invoke("Destruir",1);
        }


    }
    void Destruir()
    {
        exp.Stop();
        Destroy(this.gameObject);
       
    }
    
    void Update()
    {
        transform.position += new Vector3(0, 1.5f, 0);
        
    }
}

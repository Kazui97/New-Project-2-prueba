using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilesjefes : MonoBehaviour
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
         if (col.gameObject.GetComponent<Movi>())
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
        
    }
}

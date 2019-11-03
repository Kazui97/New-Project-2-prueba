using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiles : MonoBehaviour
{
    int caida = 30;
    public AudioClip expl;
    public ParticleSystem explocion;
    AudioSource audioexplo;
    void Start()
    {
        audioexplo = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Movi>())
        {
            //audioexplo.PlayOneShot(expl);
            explocion.Play();
            Invoke("Explo", 1);
        }
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
            gameObject.transform.position = new Vector3(Random.Range(-75, 75), 100, 0);
            }   
        }

    // Update is called once per frame
    void Update()
    {
        Caer();
    }
}

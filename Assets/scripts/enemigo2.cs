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
  //  public GameObject canon2;
    GameObject balasenemigas;
    public ParticleSystem fuego;
    public ParticleSystem humo;


    void Start()
    {
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

    void DisparoEnenmigo()
    {
        balasenemigas = Instantiate(bala, canon1.GetComponent<Transform>().position, Quaternion.identity);
       // balasenemigas = Instantiate(bala ,canon2.GetComponent<Transform>().position, Quaternion.identity);
        balasenemigas.transform.parent = null;
        balasenemigas.name = "balasEnemigas2";
        Destroy(balasenemigas, 1.5f);
    }
    public void Moverenemigo()
    {
        temp = (int)Time.timeSinceLevelLoad;
        if (temp >= 30)
        {
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
            if(vida <= 50)
            {
                humo.Play();
            }
            if (vida <= 35)
            {
                fuego.Play();
            }
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
                    humo.Stop();
                    fuego.Stop();
                    vidarestantes--;
                    if (vidarestantes == 0)
                    {
                        Destroy(this.gameObject);
                    }

                }
                StopCoroutine("nelly");
                gameObject.transform.position = new Vector3(Random.Range(-75, 75), 106, 0);
                movVert = -35;
                // humo.Stop();
                vida = 100;
                if (true)
                {
                    Invoke("LLamaCorru", 3.5f);
                }

                // gameObject.transform.position += new Vector3(0, movVert + -20 * Time.deltaTime , 0);
                // Destroy(gameObject);
                // Debug.Log ("exploto :v");
            }
            Debug.Log(vida + "avion2");


        }
    }
    void Update()
    {
       
        Moverenemigo();
        //print(temp);

    }
}

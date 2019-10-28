using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crear : MonoBehaviour
{
    public GameObject cubo;
    public float posicion1 = 0.21f;
    public float posicion2 = 0.43f;
    
    public float posicion3 = 4.43f;

    // Start is called before the first frame update
    void Start()
    {
      cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
      Vector3 pos = new Vector3(posicion1,posicion2,posicion3);
      cubo.transform.position = pos;
        cubo.AddComponent<bajar>();
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}

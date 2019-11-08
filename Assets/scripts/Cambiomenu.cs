using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiomenu : MonoBehaviour
{
    public void CambioEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Reinicio(string Nombre)
    {
        SceneManager.LoadScene(Nombre);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    GameObject sonidos;

    private void Awake()
    {
        sonidos= GameObject.FindWithTag("Sonido");
    }


        public void botonEjercicios()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        SceneManager.LoadScene(1);

    }
    public void botonUsuarios()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        SceneManager.LoadScene(2);
    }
    public void botonEstadisticas()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        SceneManager.LoadScene(3);
    }
    public void botonAtras()
    {
        sonidos.GetComponent<Sonidos>().repSonido(1);
        SceneManager.LoadScene(0);
        
    }
    public void salir()
    {
        sonidos.GetComponent<Sonidos>().repSonido(1);
        Application.Quit();
    }

    
}

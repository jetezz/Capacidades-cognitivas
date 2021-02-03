using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{   
    public void botonEjercicios()
    {
        SceneManager.LoadScene(1);
    }
    public void botonUsuarios()
    {
        SceneManager.LoadScene(2);
    }
    public void botonEstadisticas()
    {
        SceneManager.LoadScene(3);
    }
    public void botonAtras()
    {
       
        SceneManager.LoadScene(0);
        
    }
    public void salir()
    {
        Application.Quit();
    }

    
}

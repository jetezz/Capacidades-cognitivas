using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuEjercicios : MonoBehaviour
{
    public GameObject panelSalir;
    
    

   

    public void botonSarlir()
    {        
        panelSalir.SetActive(true);
    }
    public void botonSarlirMenu()
    {       
         SceneManager.LoadScene(0);      
    }
    public void botonContinuar()
    {
        panelSalir.SetActive(false);
    }
  
}

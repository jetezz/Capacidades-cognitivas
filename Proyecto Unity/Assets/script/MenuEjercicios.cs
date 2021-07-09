using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuEjercicios : MonoBehaviour
{
    public GameObject panelSalir;
    GameObject sonidos;





    public void botonSarlir()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);

        panelSalir.SetActive(true);
    }
    public void botonSarlirMenu()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(1);
        SceneManager.LoadScene(0);      
    }
    public void botonContinuar()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);
        panelSalir.SetActive(false);
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuEjercicios : MonoBehaviour
{
    public GameObject panelSalir;
    int respuestaSalir;
    public GameObject botonSalir;

   

    public void botonSarlir()
    {
        botonSalir.SetActive(false);
        panelSalir.SetActive(true);
    }
    public void botonSarlirMenu()
    {
        if (respuestaSalir == 21)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            panelSalir.transform.GetChild(5).gameObject.SetActive(true);
        }
    }
    public void botonContinuar()
    {
        panelSalir.SetActive(false);
        panelSalir.transform.GetChild(5).gameObject.SetActive(false);
        botonSalir.SetActive(true);

    }
    public void inputRespuesta(string res)
    {
        respuestaSalir = Int32.Parse(res);
    }
}

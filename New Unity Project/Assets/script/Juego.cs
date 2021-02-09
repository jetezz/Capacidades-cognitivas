using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public GameObject panelSalir;
    public int respuesta;

    public void botonSarlir()
    {
        panelSalir.SetActive(true);
    }
    public void botonSarlirMenu()
    {
        if (respuesta == 21)
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

    }
    public void inputRespuesta(string res)
    {
        respuesta = Int32.Parse(res);
    }
}

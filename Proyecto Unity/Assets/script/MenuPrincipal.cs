using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject botonEjercicios;
    public GameObject botonUsuarios;
    public GameObject botonEstadisticas;
    public GameObject volum1;
    public GameObject volum2;
    

    public GameObject panelMensaje;
    public GameObject informacion;

    public GameObject ajustes;

    public Sprite ejercicios;
    public Sprite ejercicios1;
    public Sprite usuarios1;
    public Sprite usuarios;
    public Sprite estadisticas;
    public Sprite estadisticas1;

    public float volumen = 0.5f;
    public float volumen2 = 0.5f;

    public float tiempoVolumen = 0f;


    GameObject sonidos;
    GameObject sonidos2;

    bool hayUsuarios=false;

    void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos2 = GameObject.FindWithTag("Sonido2");
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");

        hayUsuarios = managerUsuario.GetComponent<ManagerUsuario>().comprobarSiHayUsuarios();
        if (hayUsuarios)
        {
            botonEjercicios.GetComponent<Image>().sprite = ejercicios;
            botonEstadisticas.GetComponent<Image>().sprite = estadisticas;
        }
        else
        {
            botonEjercicios.GetComponent<Image>().sprite = ejercicios1;
            botonEstadisticas.GetComponent<Image>().sprite = estadisticas1;
        }
    }

    public void cerrarPanelMensaje()
    {
        panelMensaje.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(1);
    }
   

    public void pulsarEjercicios()
    {
        if (hayUsuarios)
        {
            sonidos.GetComponent<Sonidos>().repSonido(0);
            SceneManager.LoadScene(1);
        }
        else
        {
            panelMensaje.SetActive(true);
            sonidos.GetComponent<Sonidos>().repSonido(0);
        }
        

    }

    public void pulsarUsuarios()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        SceneManager.LoadScene(2);
    }

    public void pulsarEstadisticas()
    {
        if (hayUsuarios)
        {
            sonidos.GetComponent<Sonidos>().repSonido(0);
            SceneManager.LoadScene(3);
        }
        else
        {
            panelMensaje.SetActive(true);
            sonidos.GetComponent<Sonidos>().repSonido(0);
        }
        
    }
    public void abrirInformacion()
    {
        informacion.SetActive(true);
        sonidos.GetComponent<Sonidos>().repSonido(5);

    }

    public void cerrarInformacion()
    {
        informacion.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(5);


    }
    public void abrirAjustes()
    {
        ajustes.SetActive(true);
        sonidos.GetComponent<Sonidos>().repSonido(5);
        volum1.GetComponent<Slider>().value = volumen;
        volum2.GetComponent<Slider>().value = volumen2;

    }
    public void cerrarAjustes()
    {
        ajustes.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(5);
      
    }
    public void cambiarVolumen1()
    {
        volumen = volum1.GetComponent<Slider>().value;
        sonidos.GetComponent<AudioSource>().volume = volumen;        
        tiempoVolumen += Time.deltaTime;
        if (tiempoVolumen > 0.1)
        {
            tiempoVolumen = 0;
            sonidos.GetComponent<Sonidos>().repSonido(5);
        }
    }

    public void cambiarVolumen2()
    {
        volumen2 = volum2.GetComponent<Slider>().value;
        tiempoVolumen += Time.deltaTime;
        sonidos2.GetComponent<AudioSource>().volume = volumen2;
        if (tiempoVolumen > 0.1)
        {
            tiempoVolumen = 0;
            sonidos2.GetComponent<Sonidos2>().repSonido();
        }
    }

    public void cerrarAplicacion()
    {
        Application.Quit();        
    }

}

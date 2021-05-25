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

    public GameObject panelMensaje;
    public GameObject informacion;

    public Sprite ejercicios;
    public Sprite ejercicios1;
    public Sprite usuarios1;
    public Sprite usuarios;
    public Sprite estadisticas;
    public Sprite estadisticas1;

    GameObject sonidos;

    bool hayUsuarios=false;

    void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");
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


}

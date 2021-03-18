using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ManagerEjercicios : MonoBehaviour
{
    public static ManagerEjercicios managerEjercicios;
    public GameObject panelSalir;
    public int respuestaSalir;
    public int ejercicio;
    public int nivel;
    private GameObject managerUsuario;
    public Usuario usuario;



    private void Awake()
    {
        if (managerEjercicios == null)
        {
            managerEjercicios = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (managerEjercicios != this)
        {
            Destroy(gameObject);
        }
    }
  


    public void iniciarConUsuario()
    {
        managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
        
        ejercicio = usuario.getPeorEstadistica();
        ejercicio = 1;
        nivel = usuario.getNivelEstadistica(ejercicio);

        if (ejercicio == 0)
        {
            SceneManager.LoadScene(9);
        }
        if (ejercicio == 1)
        {
            SceneManager.LoadScene(8);
        }
        if (ejercicio == 2)
        {
            SceneManager.LoadScene(11);
        }
        if (ejercicio == 3)
        {
            SceneManager.LoadScene(5);
        }
        if (ejercicio == 4)
        {
            SceneManager.LoadScene(7);
        }
        if (ejercicio == 5)
        {
            SceneManager.LoadScene(12);
        }
        if (ejercicio == 6)
        {
            SceneManager.LoadScene(10);
        }
        if (ejercicio == 6)
        {
            SceneManager.LoadScene(6);
        }
    }

    public void iniciarEpecial(int eje, int niv) 
    {
        managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
        nivel = niv;
        ejercicio = eje;
        if (ejercicio == 0)
        {
            SceneManager.LoadScene(9);
        }
        if (ejercicio == 1)
        {
            SceneManager.LoadScene(8);
        }
        if (ejercicio == 2)
        {
            SceneManager.LoadScene(11);
        }
        if (ejercicio == 3)
        {
            SceneManager.LoadScene(5);
        }
        if (ejercicio == 4)
        {
            SceneManager.LoadScene(7);
        }
        if (ejercicio == 5)
        {
            SceneManager.LoadScene(12);
        }
        if (ejercicio == 6)
        {
            SceneManager.LoadScene(10);
        }
        if (ejercicio == 7)
        {
            SceneManager.LoadScene(6);
        }
    }

   










   









}

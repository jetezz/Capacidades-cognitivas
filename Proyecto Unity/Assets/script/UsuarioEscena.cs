using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsuarioEscena : MonoBehaviour
{
    public GameObject botonEliminarUsuario;
    public GameObject lista;
    void Start()
    {
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        if (managerUsuario.GetComponent<ManagerUsuario>().comprobarSiHayUsuarios())
        {
            botonEliminarUsuario.SetActive(true);
        }
        else
        {
            botonEliminarUsuario.SetActive(false);
        }
    }

    public void botonNuevoUsuario()
    {
        botonEliminarUsuario.SetActive(true);
        lista.GetComponent<Lista>().botonNuevoUsuario();
    }
    public void botonBorrarUsuario()
    {
        lista.GetComponent<Lista>().borrarUsuario();
        Start();
    }

 
}

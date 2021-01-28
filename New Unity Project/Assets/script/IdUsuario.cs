using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdUsuario : MonoBehaviour
{   
    public int id;
    public GameObject managerUsuario;
    public GameObject lista;

    public void clickUsuario()
    {
        if (managerUsuario.GetComponent<ManagerUsuario>().borrar)
        {
            lista.GetComponent<Lista>().borrarUsuario(id);
            managerUsuario.GetComponent<ManagerUsuario>().botonGuardar();
        }
        else
        {
            Debug.Log(id);
        }
    }

}


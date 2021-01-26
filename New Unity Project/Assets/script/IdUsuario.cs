using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdUsuario : MonoBehaviour
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public int id;
    public GameObject menu;
    public GameObject lista;

    public void clickUsuario()
    {
        if (menu.GetComponent<menu>().borrar)
        {
            lista.GetComponent<Lista>().borrarUsuario(id);
        }
        else
        {
            Debug.Log(id);
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsEstadiscitcas : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelDatos;
    public GameObject container;
    int id;
    Usuario usuario;


    public void usuarioPulsado(int i)
    {
        id = i;
        panel.SetActive(true);
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        panel.transform.GetChild(0).GetComponent<Text>().text= usuario.Name;
    }
    public void pulsarCapacidad(int num)
    {
        panelDatos.SetActive(true);
        panelDatos.transform.GetChild(1).GetComponent<Text>().text = usuario.getNumIntentos(num).ToString();
        panelDatos.transform.GetChild(3).GetComponent<Text>().text = usuario.getNivelMax(num).ToString();
        panelDatos.transform.GetChild(5).GetComponent<Text>().text = usuario.getNivelEstadistica(num).ToString();
        container.GetComponent<WindowsGraph>().crearEstadisticas(usuario.getTabla(num));
        string categoria="";
        if (num == 0)
        {
            categoria = "Memoria";
        }
        else if (num == 1)
        {
            categoria = "Lenguaje";

        }
        else if (num == 2)
        {
            categoria = "Percepcion";
        }
        else if (num == 3)
        {
            categoria = "Atencion";
        }
        else if (num == 4)
        {
            categoria = "Gnosias";
        }
        else if (num == 5)
        {
            categoria = "Praxias";
        }
        else if (num == 6)
        {
            categoria = "Orientacion";
        }
        else if (num == 7)
        {
            categoria = "Calculo";
        }
        container.transform.GetChild(2).gameObject.SetActive(true);
        container.transform.GetChild(2).GetComponent<Text>().text = categoria;


    }
    public void cerrarEstadisticas()
    {
        container.GetComponent<WindowsGraph>().limpiarTabla();
        panelDatos.SetActive(false);
        panel.SetActive(false);
        container.transform.GetChild(2).gameObject.SetActive(true);
    }

}
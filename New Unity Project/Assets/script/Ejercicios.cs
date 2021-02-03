using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ejercicios : MonoBehaviour
{
    public int id;
    public GameObject panel;
    public void botonCerrarPanel()
    {
        panel.SetActive(false);
       
    }
    public void ActivarPanel()
    {
        panel.SetActive(true);
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        panel.transform.GetChild(2).GetComponent<Text>().text = usuario.Name;
        panel.transform.GetChild(3).GetComponent<Text>().text = usuario.Description;
        if (usuario.estadisticas.textInicial == false)
        {
            panel.transform.GetChild(5).gameObject.SetActive(true);
        }
        else
        {
            panel.transform.GetChild(5).gameObject.SetActive(false);
        }
            


    }

    public void botonTextInicial()
    {
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        usuario.estadisticas.textInicial = true;
    }
   
}

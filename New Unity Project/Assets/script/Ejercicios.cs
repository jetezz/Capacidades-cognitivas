using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Ejercicios : MonoBehaviour
{
    public int id;
    public GameObject panel;
    public string valoresCapacidades;
    public GameObject panelCapacidades;
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
            panelCapacidades.SetActive(false);
            panel.transform.GetChild(6).gameObject.SetActive(false);
            panel.transform.GetChild(7).gameObject.SetActive(false);


        }
        else
        {
            panel.transform.GetChild(5).gameObject.SetActive(false);
            panelCapacidades.SetActive(true);
            valoresCapacidades = string.Format(usuario.getMemoria() + "{0}{0}" + usuario.getLenguaje() + "{0}{0}" + usuario.getPercepcion() + "{0}{0}" + usuario.getAtencion() + "{0}{0}" + usuario.getGnosias() + "{0}{0}" +usuario.getPraxias() + "{0}{0}" + usuario.getOrientacion() + "{0}{0}" + usuario.getCalculo(), Environment.NewLine);

            panelCapacidades.transform.GetChild(2).GetComponent<Text>().text = valoresCapacidades;

            panel.transform.GetChild(6).gameObject.SetActive(true);
            panel.transform.GetChild(7).gameObject.SetActive(true);
        }

        
        
    }

    public void botonTextInicial()
    {
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        usuario.estadisticas.textInicial = true;
        usuario.memoria(0);
        usuario.lenguaje(1);
        usuario.percepcion(2);
        usuario.atencion(3);
        usuario.gnosia(4);
        usuario.praxia(5);
        usuario.orientacion(6);
        usuario.calculo(7);
        managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();

        SceneManager.LoadScene(1);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdUsuario : MonoBehaviour
{   
    public int id;   
    public GameObject lista;
    public GameObject estadisticas;
    GameObject sonidos;

    private void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");
    }
    public void clickUsuario()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        if (lista.GetComponent<Lista>().borrar)
        {            
            lista.GetComponent<Lista>().alertaBorrarUsuario(id);          
        }
        else
        {
            lista.GetComponent<Lista>().abrirPanelCaracteristicas(id);
        }
    }
    public void clickUsuarioEjercicios()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        GameObject ejercicios = GameObject.FindWithTag("Ejercicios");
        ejercicios.GetComponent<Ejercicios>().id = id;
        ejercicios.GetComponent<Ejercicios>().ActivarPanel();

    }
    public void estadisticasUsuario()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        estadisticas.GetComponent<EsEstadiscitcas>().usuarioPulsado(id);
    }
    
  

}


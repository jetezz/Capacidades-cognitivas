using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdUsuario : MonoBehaviour
{   
    public int id;   
    public GameObject lista;
    public GameObject estadisticas;
    

    public void clickUsuario()
    {
        
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
        GameObject ejercicios = GameObject.FindWithTag("Ejercicios");
        ejercicios.GetComponent<Ejercicios>().id = id;
        ejercicios.GetComponent<Ejercicios>().ActivarPanel();

    }
    public void estadisticasUsuario()
    {
        estadisticas.GetComponent<EsEstadiscitcas>().usuarioPulsado(id);
    }
    
  

}


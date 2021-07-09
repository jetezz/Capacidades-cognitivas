using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdSeleccion : MonoBehaviour
{
    public bool correcto = false;
    public int id;
    public GameObject percepcion;

    public void botonPulsado()
    {
        percepcion.GetComponent<Percepcion>().eventoPulsado(correcto,id);
    }

    public void botonPulsadoN4Izquierda()
    {
        percepcion.GetComponent<Percepcion>().eventoSeleccionNivel4(id,true);
       
    }
    public void botonPulsadoN4Derecha()
    {
        percepcion.GetComponent<Percepcion>().eventoSeleccionNivel4(id,false);
    }
}

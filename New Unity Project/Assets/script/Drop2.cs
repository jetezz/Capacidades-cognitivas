using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop2 : MonoBehaviour, IDropHandler
{
    public GameObject lenguaje;
    GameObject sonidos;
    public void OnDrop(PointerEventData eventData)
    {
        Drag2 d = eventData.pointerDrag.GetComponent<Drag2>();
        if (d != null)
        {
            d.pointofreturn = this.transform;
            lenguaje.GetComponent<Lenguaje>().comprobarNumRespuesta();
        }
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(6);

    }

  
}

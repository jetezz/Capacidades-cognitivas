using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotOrientacion : MonoBehaviour, IDropHandler
{
    public GameObject orientacion;
    public int x;
    public int y;
    public int id;
    GameObject sonidos;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        id = eventData.pointerDrag.GetComponent<IdSeleccion>().id;
        orientacion.GetComponent<Orientacion>().respuestaN4(x, y, id);
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(6);
    }
}

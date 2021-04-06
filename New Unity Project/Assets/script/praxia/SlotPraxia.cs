using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SlotPraxia : MonoBehaviour, IDropHandler
{
    public GameObject praxia;
    public int id;
    GameObject sonidos;

    public void OnDrop(PointerEventData eventData)
    {


        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        if (eventData.pointerDrag.GetComponent<Drag>().id == id)
        {
            praxia.GetComponent<Praxia>().resultados[id]=true;
        }
        else
        {
            praxia.GetComponent<Praxia>().resultados[id] = false;
        }

        praxia.GetComponent<Praxia>().nuevaRespuesta();
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(6);

    }
}

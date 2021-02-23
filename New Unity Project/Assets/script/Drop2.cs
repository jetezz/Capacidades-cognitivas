using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop2 : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject lenguaje;
    public void OnDrop(PointerEventData eventData)
    {
        Drag2 d = eventData.pointerDrag.GetComponent<Drag2>();
        if (d != null)
        {
            d.pointofreturn = this.transform;
            lenguaje.GetComponent<Lenguaje>().comprobarNumRespuesta();
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
}

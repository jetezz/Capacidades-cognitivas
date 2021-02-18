using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject memoria;
    public int id;

    public void OnDrop(PointerEventData eventData)
    {
        
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.GetComponent<Drag>().id == id)
            {
                memoria.GetComponent<Memoria>().sumarPunto(id,true);
            }
            else
            {
                memoria.GetComponent<Memoria>().sumarPunto(id, false);
            }
           
        }
    }
}

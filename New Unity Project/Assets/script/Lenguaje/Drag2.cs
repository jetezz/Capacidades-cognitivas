using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag2 : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform pointofreturn = null;
    public int id;
    GameObject sonidos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        pointofreturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(5);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(pointofreturn);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}

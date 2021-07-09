using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pru : MonoBehaviour ,IEndDragHandler, IDragHandler, IBeginDragHandler
{

    public GameObject text1;
    public GameObject text2;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("mover");
        text1.GetComponent<Text>().text = "moviendo";
        this.transform.position = eventData.position;
    }  

    public void OnEndDrag(PointerEventData eventData)
    {
        text1.GetComponent<Text>().text = "soltado";
        GetComponent<CanvasGroup>().blocksRaycasts = true;


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Drag : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
   
    private CanvasGroup canvasGroup;
    public int id;
    public Vector3 posInicial;
    GameObject sonidos;




    public void iniciarposicion()
    {
        posInicial = transform.position;
    }
  
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        // canvasGroup = GetComponent<CanvasGroup>();
        // canvasGroup.alpha = .6f;
        //canvasGroup.blocksRaycasts = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(5);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
       
    }
 

    public void OnEndDrag(PointerEventData eventData)
    {
        //canvasGroup = GetComponent<CanvasGroup>();
        //canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
       
        GetComponent<CanvasGroup>().blocksRaycasts = true;


    }

    public void resetPosition()
    {
        transform.position = posInicial;
    }

    
 
}

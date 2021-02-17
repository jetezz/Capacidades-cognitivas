using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler, IDropHandler
{
   
    private CanvasGroup canvasGroup;
   
    
    
   
  
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = .6f;
       canvasGroup.blocksRaycasts = false;

        
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pru2 : MonoBehaviour, IDropHandler
{
    public GameObject text2;

    public void OnDrop(PointerEventData eventData)
    {
        text2.GetComponent<Text>().text = "cae algo";
    }
}

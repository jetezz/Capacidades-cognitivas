using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class WindowsGraph : MonoBehaviour
{
   [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    public GameObject container;

    public void crearEstadisticas(List<int> list)
    {
        limpiarTabla();

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();     
        ShowGraph(list);
    }
    public void limpiarTabla()
    {
        while (container.transform.childCount > 0)
        {
            DestroyImmediate(container.transform.GetChild(0).gameObject);
        }
    }

    private GameObject createCircle(Vector2 anchoredPosicition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosicition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }
    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 5f;
        float xSize = 50f;
        GameObject LastCircleGameObject = null;
        for(int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize+i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject= createCircle(new Vector2(xPosition, yPosition));
            if (LastCircleGameObject != null)
            {
                createDotConnection(LastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            LastCircleGameObject = circleGameObject;
        }
    }
    private void createDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA+ dir *distance *.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));




    }
}

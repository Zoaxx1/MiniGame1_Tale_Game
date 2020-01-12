using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Container : MonoBehaviour, IDropHandler
{
    [SerializeField] private string objects;

    [SerializeField] private string typeId;

    private ScoreScript scoreScript;

    [SerializeField]private int count = 0;

    private void Start()
    {
        scoreScript = GameObject.Find("Score").GetComponent<ScoreScript>();
    }

    private void Update()
    {
        typeId = scoreScript.items[scoreScript.randomItem[scoreScript.i]];
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Containable>().tipe == objects)
        {
            if(eventData.pointerDrag.GetComponent<Containable>().id == typeId)
            {
                eventData.pointerDrag.GetComponent<DragHandler>().itsInside = true;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.SetActive(false);
                count++;
                if(count == scoreScript.score)
                {
                    scoreScript.ScoreFunction();
                    count = 0;
                }
            }
        }
        else
        {
            Debug.Log("Its Wrong");
        }
    }

    
}

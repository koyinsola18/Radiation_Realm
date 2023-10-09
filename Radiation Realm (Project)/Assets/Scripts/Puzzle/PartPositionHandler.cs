using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartPositionHandler : MonoBehaviour, IDropHandler
{
    public int id;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
	if (eventData.pointerDrag != null)
	{
	    if (eventData.pointerDrag.GetComponent<PartHandler>().id == id)
            {
	        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
	    }
	    else
	    {
	        eventData.pointerDrag.GetComponent<PartHandler>().ResetPosition();
	    }
        }
    }
}

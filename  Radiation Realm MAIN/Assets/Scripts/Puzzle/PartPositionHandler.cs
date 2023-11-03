using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartPositionHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    public int id;
    int counter = 0;
    public int puzzle_to_be_solved = 3;
    public GameObject DragandDropPuzzleCanvas;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<PartHandler>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        this.GetComponent<RectTransform>().anchoredPosition;
                audioSource.PlayOneShot(clips[0]);

                counter++;
                //Number of items that needs to be dropped for puzzle to close
                if (counter >= puzzle_to_be_solved)
                {
                    CloseCanvas();

                }
                else
                {
                    eventData.pointerDrag.GetComponent<PartHandler>().ResetPosition();
                }
            }
        }
        void CloseCanvas()
        {
            if (DragandDropPuzzleCanvas != null)
            {
                DragandDropPuzzleCanvas.SetActive(false);
            }



        }

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SortingBin : MonoBehaviour, IDropHandler
{
    public string binType; // Assign this in the Unity editor (e.g., "PlasticBin", "MetalBin", "PaperBin")
    public Text instructionText;
    public GameController gameController;

    private bool isDragging = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isDragging)
        {
            TrashItem trashItem = eventData.pointerDrag.GetComponent<TrashItem>();

            if (trashItem != null && trashItem.trashType.Equals(binType))
            {
                Destroy(trashItem.gameObject);
                gameController.ItemSorted();
            }
            else
            {
                // Optional: Provide feedback to the player for incorrect sorting
                Debug.Log("Incorrect sorting. Try again!");
            }

            isDragging = false;
        }
    }
}

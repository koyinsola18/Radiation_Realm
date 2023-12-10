using UnityEngine;
using UnityEngine.EventSystems;

public class TrashItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string trashType; // Assign this in the Unity editor (e.g., "Plastic", "Metal", "Paper")
    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the item is dropped over a valid drop zone
        if (eventData.pointerCurrentRaycast.isValid)
        {
            SortingBin sortingBin = eventData.pointerCurrentRaycast.gameObject.GetComponent<SortingBin>();

            // Check if the sorting bin exists and if it accepts the dragged item
            if (sortingBin != null && sortingBin.binType.Equals(trashType))
            {
                // The correct trash item is dropped into the right bin
                Destroy(gameObject);
                sortingBin.gameController.ItemSorted();
                return;
            }
        }

        // If the item is not dropped over a valid drop zone or into the correct bin, return it to its initial position
        transform.position = initialPosition;
    }
}

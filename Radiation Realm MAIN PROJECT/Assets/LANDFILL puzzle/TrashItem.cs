using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrashItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public string trashItemType; // Tag or identifier for the type of trash item

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Handle the end of the drag
        GameManager.Instance.CheckSorting(GetComponent<Image>(), trashItemType);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text winText;
    public Image gravityBootsImage;
    public Text sortedItemCountText;

    private int itemsToSort;
    private int sortedItems;

    void Start()
    {
        // Count the total number of items to sort
        itemsToSort = GameObject.FindGameObjectsWithTag("TrashItem").Length;
        sortedItems = 0;

        // Disable win text and gravity boots image at the start
        winText.enabled = false;
        gravityBootsImage.enabled = false;

        // Update the UI Text to show the initial count of sorted items
        UpdateSortedItemCountText();
    }

    public void ItemSorted()
    {
        sortedItems++;

        // Update the UI Text whenever an item is sorted
        UpdateSortedItemCountText();

        if (sortedItems == itemsToSort)
        {
            // All items have been sorted
            DisplayWinScreen();
        }
    }

    private void DisplayWinScreen()
    {
        // Enable win text and gravity boots image
        winText.enabled = true;
        gravityBootsImage.enabled = true;
    }

    private void UpdateSortedItemCountText()
    {
        // Update the UI Text to show the current count of sorted items
        sortedItemCountText.text = "Items Sorted: " + sortedItems + " / " + itemsToSort;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image[] wearablesBin;   // Reference to wearables bin
    public Image[] electronicsBin; // Reference to electronics bin
    public Image[] extrasBin;      // Reference to extras bin

    public Text winText;         // Reference to win text
    public Image gravityBootsImage; // Reference to the gravity boots image

    private bool gameWon = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        winText.gameObject.SetActive(false);
        gravityBootsImage.gameObject.SetActive(false);
    }

    public void CheckSorting(Image item, string trashItemType)
    {
        // Determine the correct bin based on the trashItemType
        Image[] targetBin = null;

        switch (trashItemType)
        {
            case "Wearable":
                targetBin = wearablesBin;
                break;
            case "Electronic":
                targetBin = electronicsBin;
                break;
            case "Extra":
                targetBin = extrasBin;
                break;
        }

        // Iterate through the target bin and check if the item is over it
        foreach (Image bin in targetBin)
        {
            RectTransform binRectTransform = bin.GetComponent<RectTransform>();

            if (IsRectTransformOverlapping(item.rectTransform, binRectTransform))
            {
                // Check if the bin is empty
                if (bin.transform.childCount == 0)
                {
                    item.gameObject.SetActive(false);
                    CheckWinCondition();
                    return;
                }
            }
        }

        // If not over a correct bin or the bin is not empty, reset item position
        item.rectTransform.anchoredPosition = new Vector2(0, 0);
    }

    private void CheckWinCondition()
    {
        // Check if all bins are empty
        if (wearablesBin[0].transform.childCount == 0 &&
            electronicsBin[0].transform.childCount == 0 &&
            extrasBin[0].transform.childCount == 0 &&
            !gameWon)
        {
            // Player wins
            winText.gameObject.SetActive(true);
            gravityBootsImage.gameObject.SetActive(true);
            gameWon = true;
        }
    }

    // Helper method to check if two RectTransforms overlap
    private bool IsRectTransformOverlapping(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.position.x, rectTrans1.position.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.position.x, rectTrans2.position.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}


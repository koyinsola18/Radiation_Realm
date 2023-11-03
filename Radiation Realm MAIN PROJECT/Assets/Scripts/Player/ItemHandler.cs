using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemCount;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject puzzleCanvas;
    int item;

    void Start()
    {
        puzzleCanvas.SetActive(false);
    }
    

    public void CollectItem()
    {
        item++;
    }

    void Update()
    {
        
        if(item == 5)
        {
            puzzleCanvas.SetActive(true);
            itemCount.text = "";
            text.text = "";
        }
        else
        {
            itemCount.text = item.ToString();
        }
        
    }

    public void ClosePuzzleCanvas()
    {
        puzzleCanvas.SetActive(false);
        item++;
    }
}

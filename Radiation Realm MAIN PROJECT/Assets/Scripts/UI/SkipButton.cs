using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    public TextforWinScene text; // Reference to the StarWarsCrawl script

    void Start()
    {
        if (text == null)
        {
            text = FindObjectOfType<TextforWinScene>();
        }

        // Attach the button click event
        GetComponent<Button>().onClick.AddListener(SkipCrawl);
    }

    void SkipCrawl()
    {
        // Call the method in the StarWarsCrawl script to skip the crawl
        text.SkipCrawl();
    }
}


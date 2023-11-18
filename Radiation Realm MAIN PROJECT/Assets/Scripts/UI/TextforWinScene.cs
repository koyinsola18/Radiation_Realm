using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextforWinScene : MonoBehaviour
{
    public TMP_Text crawlText;
    public float scrollSpeed = 20f;

    void Update()
    {
        ScrollCrawl();
    }

    void ScrollCrawl()
    {
        Vector3 pos = crawlText.transform.position;
        pos.y += scrollSpeed * Time.deltaTime;
        crawlText.transform.position = pos;
    }
public void SkipCrawl()
{
    // Set a large positive value to move the text far beyond the visible area
    Vector3 pos = crawlText.transform.position;
    pos.y = 10000f;
    crawlText.transform.position = pos;
}
}


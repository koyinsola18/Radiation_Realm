using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarWarsCrawl : MonoBehaviour
{
    public Text crawlText;
    public float scrollSpeed = 20f;

    void Start()
    {
        InitializeCrawl();
    }

    void Update()
    {
        ScrollCrawl();
    }

    void InitializeCrawl()
    {
        crawlText.text = "A long time ago in a galaxy far, far away....\nYour text goes here. Add more lines as needed.";
    }

    void ScrollCrawl()
    {
        Vector3 pos = crawlText.transform.position;
        pos.y += scrollSpeed * Time.deltaTime;
        crawlText.transform.position = pos;
    }
}
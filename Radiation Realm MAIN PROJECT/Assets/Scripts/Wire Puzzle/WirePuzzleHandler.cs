using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleHandler : MonoBehaviour
{
    [SerializeField] GameObject wirePuzzle;
    void OnTriggerEnter2D(Collider2D col)
    {
        wirePuzzle.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        wirePuzzle.SetActive(false);
    }
}

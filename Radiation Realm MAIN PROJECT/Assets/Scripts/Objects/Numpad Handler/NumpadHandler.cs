using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadHandler : MonoBehaviour
{
    [SerializeField] GameObject numberPuzzle;

    [SerializeField] GameObject popUp;

    bool lightTurned = false;
    private bool isInRange = false;


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            numberPuzzle.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            popUp.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            popUp.SetActive(false);
            isInRange = false;
        }
    }
    public void PuzzleComplete()
    {
        numberPuzzle.SetActive(false);
    }
}

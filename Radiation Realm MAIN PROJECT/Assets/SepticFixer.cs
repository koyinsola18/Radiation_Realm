using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SepticFixer : MonoBehaviour
{

    [SerializeField] GameObject septicDragPuzzle;

    [SerializeField] GameObject popUp;

    [SerializeField] GameObject toxicDrops;


    private bool isInRange = false;

    void Start()
    {
       
    }


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            septicDragPuzzle.SetActive(true);
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
        septicDragPuzzle.SetActive(false);
        toxicDrops.SetActive(false);

    }

}

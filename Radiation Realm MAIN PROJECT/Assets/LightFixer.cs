using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFixer : MonoBehaviour
{
    [SerializeField] GameObject septicDragPuzzle;

    [SerializeField] GameObject popUp;

    [SerializeField] Light2D sewerLight;


    private bool isInRange = false;


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
        //sewerLight.color = new Color(255f, 255f, 255f);
        sewerLight.intensity = 1;

    }
}

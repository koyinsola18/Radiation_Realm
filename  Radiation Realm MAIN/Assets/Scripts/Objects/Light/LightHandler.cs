using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightHandler : MonoBehaviour
{
    [SerializeField] Color darkRoomColor;
    [SerializeField] Color brightRoomColor;

    [SerializeField] Light2D globalLight;
    [SerializeField] GameObject numberPuzzle;

    [SerializeField] GameObject popUp;

    public float colorLerpTime = 2f;



    bool lightTurned = false;
    private bool isInRange = false;

    void Start()
    {
        globalLight.color = darkRoomColor;
    }

   
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
        globalLight.color = brightRoomColor;
        lightTurned = true;
    }

}

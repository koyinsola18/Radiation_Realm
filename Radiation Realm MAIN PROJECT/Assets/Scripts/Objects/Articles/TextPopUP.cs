using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUP : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] GameObject popUpButton;

    private bool isInRange = false;
    public bool isArticleOn = false;

    void Start()
    {
        popUp.SetActive(false);
        popUpButton.SetActive(false);
    }

    void Update()
    {

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            popUp.SetActive(true);
            isArticleOn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            popUpButton.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            popUpButton.SetActive(false);
            popUp.SetActive(false);
            isInRange = false;
        }
    }
}

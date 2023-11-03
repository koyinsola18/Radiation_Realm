using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    [SerializeField] GameObject popUp;

    private bool isInRange = false;

    public ItemHandler itemHandler;

    void Start()
    {
        popUp.SetActive(false);
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            itemHandler.CollectItem();
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
}

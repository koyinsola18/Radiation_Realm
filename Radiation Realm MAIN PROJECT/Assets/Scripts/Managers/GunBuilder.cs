using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBuilder : MonoBehaviour
{
    [SerializeField] GameObject gunBuilderDragPuzzle;
    [SerializeField] GameObject popUp;

    [SerializeField] GunSwitcher gunSwitcher;


    private bool isInRange = false;
    bool isPuzzleComplete = false;


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !isPuzzleComplete)
        {
            gunBuilderDragPuzzle.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isPuzzleComplete)
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
        gunBuilderDragPuzzle.SetActive(false);
        isPuzzleComplete = true;
        gunSwitcher.AddGunToInventory();
    }
}

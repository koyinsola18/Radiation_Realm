using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBuilder : MonoBehaviour
{
    [SerializeField] GameObject gunBuilderDragPuzzle;
    [SerializeField] GameObject popUp;

    [SerializeField] GunSwitcher gunSwitcher;


    public AudioSource audioSource;
    public AudioClip clip;

    public GameObject gravityGunNotification;


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
            gunBuilderDragPuzzle.SetActive(false);
            popUp.SetActive(false);
            isInRange = false;
        }
    }
    public void PuzzleComplete()
    {
        isPuzzleComplete = true;
        gunSwitcher.AddGunToInventory();
        gunBuilderDragPuzzle.SetActive(false);
        audioSource.PlayOneShot(clip);
        gravityGunNotification.SetActive(true);
        StartCoroutine(NotificationOff());
    }

    IEnumerator NotificationOff()
    {
        yield return new WaitForSeconds(4f);
        gravityGunNotification.SetActive(false);
    }
}

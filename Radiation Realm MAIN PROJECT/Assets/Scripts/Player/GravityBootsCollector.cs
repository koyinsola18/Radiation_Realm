using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBootsCollector : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] CharacterController2D player;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] GameObject notification;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [SerializeField] Collider2D col;

    [SerializeField] GameObject bootLight;

    private bool isInRange = false;


    void Start()
    {
        popUp.SetActive(false);
        notification.SetActive(false);
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            sp.enabled = false;
            player.BootUsage();
            notification.SetActive(true);
            StartCoroutine(NotificationOff());
            audioSource.PlayOneShot(audioClip);
            col.enabled = false;
            bootLight.SetActive(false);
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
    IEnumerator NotificationOff()
    {
        yield return new WaitForSeconds(4f);
        notification.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtHandler : MonoBehaviour
{
    public float activeTime = 1f;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DeactiveHurt());
        }       
    }
    IEnumerator DeactiveHurt()
    {
        // Check if the audio is not playing
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }

        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }
}

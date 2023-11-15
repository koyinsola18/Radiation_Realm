using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearTime = 2f; // Time in seconds before the platform disappears.

    private bool playerOnPlatform = false;

    void Update()
    {
        // Check if the player is on the platform.
        if (playerOnPlatform)
        {
            // Decrease the disappear time.
            disappearTime -= Time.deltaTime;

            // Check if the disappear time has elapsed.
            if (disappearTime <= 0)
            {
                // Make the platform disappear.
                gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the platform.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Reset the disappear time when the player leaves the platform.
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            disappearTime = 2f; // Reset the disappear time.
        }
    }
}

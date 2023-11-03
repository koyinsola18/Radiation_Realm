using System.Collections;
using UnityEngine;

public class TimedLaser : MonoBehaviour
{
    public GameObject laser; // Reference to the laser GameObject
    public float activationTime;
    private bool isLaserActive = true; // Initial state

    void Start()
    {
        // Start the laser control coroutine
        StartCoroutine(ToggleLaser());
    }

    IEnumerator ToggleLaser()
    {
        while (true)
        {
            // Toggle the laser state
            isLaserActive = !isLaserActive;

            // Activate/deactivate the laser GameObject
            laser.SetActive(isLaserActive);

            // Wait for 3 seconds
            yield return new WaitForSeconds(activationTime);
        }
    }
}



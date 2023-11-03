using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcherUI : MonoBehaviour
{
    public GameObject[] guns; // Array to hold your gun GameObjects
    private int currentGunIndex = 0;

    private void Start()
    {
        // Disable all guns except the first one (index 0)
        for (int i = 1; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

    private void Update()
    {
        // Check for scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            // Toggle off the current gun
            guns[currentGunIndex].SetActive(false);

            // Calculate the new gun index
            currentGunIndex += (int)Mathf.Sign(scrollInput);

            // Wrap around the index if it goes out of bounds
            if (currentGunIndex < 0)
            {
                currentGunIndex = guns.Length - 1;
            }
            else if (currentGunIndex >= guns.Length)
            {
                currentGunIndex = 0;
            }

            // Toggle on the new gun
            guns[currentGunIndex].SetActive(true);
        }
    }
}

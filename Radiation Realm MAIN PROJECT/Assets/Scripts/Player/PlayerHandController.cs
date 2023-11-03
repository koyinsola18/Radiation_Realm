using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public Transform player; // Reference to the player's GameObject
    public Camera mainCamera; // Reference to the main camera

    private void Start()
    {
        mainCamera = Camera.main; // Find the main camera in the scene
    }

    private void Update()
    {
        // Ensure that the player and mainCamera references are set
        if (player == null || mainCamera == null)
            return;

        // Get the mouse position in world coordinates
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse
        Vector3 direction = (mousePosition - player.position).normalized;

        // Calculate the angle between the direction and the right vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

        // Rotate the hand to point towards the mouse
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

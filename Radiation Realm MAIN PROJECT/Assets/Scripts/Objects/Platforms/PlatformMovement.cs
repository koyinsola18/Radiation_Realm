using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 3f; // Total distance the platform can move.
    public float moveSpeed = 2f;    // Speed at which the platform moves.

    private Vector3 initialPosition;
    private float moveDirection = 1; // 1 for right, -1 for left
    private float currentDistance = 0;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the platform horizontally within the specified range.
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);

        // Move child objects along with the platform.
        MoveChildrenWithPlatform();

        // Update the current distance moved.
        currentDistance += moveSpeed * Time.deltaTime;

        // Check if the platform has reached the allowed distance.
        if (Mathf.Abs(currentDistance) >= moveDistance)
        {
            // Change the move direction to reverse the movement.
            moveDirection *= -1;
            currentDistance = 0; // Reset the current distance.
        }
    }

    void MoveChildrenWithPlatform()
    {
        // Iterate through all child objects of the platform.
        foreach (Transform child in transform)
        {
            // Move each child object horizontally with the platform.
            child.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    public bool startFromPointA = true;

    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize the target position based on the starting point.
        if (startFromPointA)
        {
            targetPosition = pointA.position;
        }
        else
        {
            targetPosition = pointB.position;
        }
    }

    private void Update()
    {
        // Move the object towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position.
        if (transform.position == targetPosition)
        {
            // Switch the target position between pointA and pointB.
            if (targetPosition == pointA.position)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
        }
    }
}

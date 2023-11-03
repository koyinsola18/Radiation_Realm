using UnityEngine;

public class GunController : MonoBehaviour
{
    public float attractForce = 10f;
    public float repelForce = 10f;
    public float maxDistanceToShowLine = 10f; // Maximum distance to show the line

    private bool isConnected = false; // Flag to track if there is a connection

    private void Update()
    {
        // Check if there's a nearby object to connect the line to
        isConnected = CheckForConnection();

        if (Input.GetKey(KeyCode.Mouse1)) // Use left mouse button as the attract action
        {
            AttractObjects();
        }
        else if (Input.GetKey(KeyCode.Mouse0)) // Use right mouse button as the repel action
        {
            RepelObjects();
        }
    }

    private void AttractObjects()
    {
        // Find all objects with the AttractedObject script
        AttractedObject[] attractedObjects = FindObjectsOfType<AttractedObject>();

        foreach (AttractedObject obj in attractedObjects)
        {
            Vector2 forceDirection = (obj.transform.position - transform.position).normalized;
            obj.ApplyForce(attractForce * forceDirection);
        }
    }

    private void RepelObjects()
    {
        // Find all objects with the AttractedObject script
        AttractedObject[] attractedObjects = FindObjectsOfType<AttractedObject>();

        foreach (AttractedObject obj in attractedObjects)
        {
            Vector2 forceDirection = (transform.position - obj.transform.position).normalized;
            obj.ApplyForce(repelForce * forceDirection);
        }
    }

    private bool CheckForConnection()
    {
        // Find the nearest attracted object (you can customize this logic)
        AttractedObject[] attractedObjects = FindObjectsOfType<AttractedObject>();
        foreach (AttractedObject obj in attractedObjects)
        {
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance <= maxDistanceToShowLine)
            {
                return true; // There's a connection
            }
        }
        return false; // No connection found
    }
}

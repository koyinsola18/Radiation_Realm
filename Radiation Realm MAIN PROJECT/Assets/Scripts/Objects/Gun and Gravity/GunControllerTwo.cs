using UnityEngine;

public class GunControllerTwo : MonoBehaviour
{
    public float force = 10f;
    public float maxDistanceToShowLine = 10f; // Maximum distance to show the line

    private GameObject hoveredObject; // The object currently hovered by the mouse

    private void Update()
    {
        // Check for mouse hover
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            hoveredObject = hit.collider.gameObject;
        }
        else
        {
            hoveredObject = null;
        }

        // Check if any mouse button is pressed and there is a valid object under the mouse cursor
        if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && hoveredObject != null)
        {
            ApplyForceToHoveredObject();
        }
    }

    private void ApplyForceToHoveredObject()
    {
        if (hoveredObject.TryGetComponent(out AttractedObject attractedObject))
        {
            Vector2 forceDirection = (hoveredObject.transform.position - transform.position).normalized;

            // Determine the force based on the mouse button being pressed
            float appliedForce = Input.GetMouseButton(1) ? force : -force;

            attractedObject.ApplyForce(appliedForce * forceDirection);
        }
    }
}

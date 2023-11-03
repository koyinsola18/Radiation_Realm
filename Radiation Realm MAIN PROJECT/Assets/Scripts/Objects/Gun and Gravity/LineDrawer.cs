using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public Transform player; // Assign your player character to this field in the Inspector.
    private LineRenderer lineRenderer;
    private bool drawing = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned! Please assign the player GameObject in the Inspector.");
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            drawing = true;
        }

        if (drawing)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPosition = player.position;

            // Set the line positions.
            lineRenderer.SetPosition(0, playerPosition);
            lineRenderer.SetPosition(1, mousePosition);
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            drawing = false;
            // Hide the line by setting the positions to the same point (zero).
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}

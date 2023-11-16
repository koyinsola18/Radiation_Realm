using UnityEngine;
using UnityEngine.PlayerLoop;

public class AttractedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isAttracted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 10;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            //rb.bodyType = RigidbodyType2D.Static;
            rb.drag = 10;
        }
    }

    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
        rb.drag = 5;
    }
}

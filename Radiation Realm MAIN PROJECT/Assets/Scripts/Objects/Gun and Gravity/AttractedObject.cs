using UnityEngine;

public class AttractedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isAttracted = false;
    public GameObject highlighter;
    public float normalMass = 250f;
    public float gravityGunMass = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //highlighter.SetActive(false);
        rb.mass = normalMass;
    }

    public void ApplyForce(Vector2 force)
    {
        rb.mass = gravityGunMass;
        print(force);
        rb.AddForce(force);
    }

    void OnMouseOver()
    {
        if(highlighter == null)
        {
            return;
        }
        highlighter.SetActive(true);
    }

    void OnMouseExit()
    {
        if (highlighter == null)
        {
            return;
        }
        highlighter.SetActive(false);
        rb.mass = normalMass;

    }
}

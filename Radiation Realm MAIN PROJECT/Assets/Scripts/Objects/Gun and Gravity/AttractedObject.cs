using UnityEngine;
using UnityEngine.PlayerLoop;

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

    void Update()
    {
        
    }

    public void ApplyForce(Vector2 force)
    {
        rb.mass = gravityGunMass;
        rb.AddForce(force);
        rb.bodyType = RigidbodyType2D.Dynamic;
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

using UnityEngine;
using UnityEngine.PlayerLoop;

public class AttractedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isAttracted = false;
    public GameObject highlighter;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //highlighter.SetActive(false);
        //rb.drag = 10;
    }

    void Update()
    {
        
    }

    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
        rb.bodyType = RigidbodyType2D.Dynamic;
        //rb.drag = 5;
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

    }
}

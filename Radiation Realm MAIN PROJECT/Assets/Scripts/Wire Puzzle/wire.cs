using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        //mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //check for nearby connection points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            //make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                //update wire to the connection point position
                UpdateWire(collider.transform.position);

                //check if wires are the same colour
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    //count connection
                    Main.Instance.SwitchChange(1);
                    //finish step 
                    collider.GetComponent<wire>()?.Done();
                    Done();
                }
                return;
            }
        }

        //wire
        UpdateWire(newPosition);
    }

    void Done()
    {
        //turn on light
        lightOn.SetActive(true);

        //destroy script
        Destroy (this);
    }
    private void OnMouseExit()
    {
        //reset wire position
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        //update position
        transform.position = newPosition;

        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        //update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicDrop : MonoBehaviour
{
    [SerializeField] float radiationIncreaseAmount = 5f; 

    // Reference to the RadiationLevel Script
    [SerializeField] RadiationLevel radiationLevel;

    void Start()
    {
        // Find the RadiationLevel script in the scene
        radiationLevel = FindObjectOfType<RadiationLevel>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && radiationLevel != null)
        {
            // Increase the radiation level
            radiationLevel.RadiationDamage(radiationIncreaseAmount);
            Destroy(gameObject);
        }
    }
}
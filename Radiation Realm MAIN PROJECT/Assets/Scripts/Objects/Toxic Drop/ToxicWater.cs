using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicWater : MonoBehaviour
{
    [SerializeField] RadiationLevel radiationLevel;
    [SerializeField] float damageAmount = 3f;
    [SerializeField] float damagePeriod = 3f;


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip splashSound;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            radiationLevel.RadiationDamage(damageAmount);
            StartCoroutine(DamageInterval());
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioSource.PlayOneShot(splashSound);
        }
    }

    IEnumerator DamageInterval()
    {
        yield return new WaitForSeconds(damagePeriod);
    }
}

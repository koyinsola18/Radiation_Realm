using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicDropSpawner : MonoBehaviour
{
    [SerializeField] GameObject toxicDrop;
    [SerializeField] Transform dropPosition;

    public void SpawnObject()
    {
        Instantiate(toxicDrop,dropPosition.position, Quaternion.identity);

    }
    
}

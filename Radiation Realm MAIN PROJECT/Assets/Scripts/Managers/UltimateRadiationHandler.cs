using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Data.Util.KeywordDependentCollection;

public class UltimateRadiationHandler : MonoBehaviour
{
    private static UltimateRadiationHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{

    [SerializeField] Color darkRoomColor;
    [SerializeField] Color brightRoomColor;

    [SerializeField] Light2D globalLight;

    bool lightTurned = false;


    void Start()
    {
        globalLight.color = darkRoomColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || !lightTurned)
        {
            globalLight.color = brightRoomColor;
            lightTurned = true;
        }
        else if (Input.GetKeyDown(KeyCode.L) || lightTurned)
        {
            globalLight.color = darkRoomColor;
            lightTurned = false;
        }
    }
}

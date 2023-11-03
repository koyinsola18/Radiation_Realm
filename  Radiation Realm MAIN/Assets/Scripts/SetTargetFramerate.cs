using UnityEngine;
using UnityEngine.PlayerLoop;

public class SetTargetFramerate : MonoBehaviour
{
    public int targetFrameRate = 30;

    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }
    private void Update()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}

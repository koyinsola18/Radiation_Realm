using UnityEngine;
using UnityEngine.UI;

public class Pipescript2 : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    GameManager2 gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager2").GetComponent<GameManager2>();
    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.CorrectMove();
            }
        }
    }

    public void RotatePipe()
    {
        if (!isPlaced)
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if (PossibleRots > 1)
            {
                if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
                {
                    isPlaced = true;
                    gameManager.CorrectMove();
                }
                else if (isPlaced)
                {
                    isPlaced = false;
                    gameManager.WrongMove();
                }
            }
            else
            {
                if (transform.eulerAngles.z == correctRotation[0])
                {
                    isPlaced = true;
                    gameManager.CorrectMove();
                }
                else if (isPlaced)
                {
                    isPlaced = false;
                    gameManager.WrongMove();
                }
            }
        }
    }
}

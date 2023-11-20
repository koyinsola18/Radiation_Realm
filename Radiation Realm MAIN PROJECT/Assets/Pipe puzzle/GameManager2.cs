using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public GameObject PipesHolder;
    public Pipescript2[] Pipes;

    [SerializeField]
    int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;

    public Text WinText;

    void Start()
    {
        WinText.gameObject.SetActive(false);
        Pipes = PipesHolder.GetComponentsInChildren<Pipescript2>();
        totalPipes = Pipes.Length;

        foreach (Pipescript2 pipe in Pipes)
        {
            Button pipeButton = pipe.GetComponent<Button>();
            pipeButton.onClick.AddListener(pipe.RotatePipe);
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;

        Debug.Log("Correct Move");

        if (correctedPipes == totalPipes)
        {
            Debug.Log("You win!");
            WinText.gameObject.SetActive(true);
        }
    }

    public void WrongMove()
    {
        correctedPipes -= 1;
    }
}


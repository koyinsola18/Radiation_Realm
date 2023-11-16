using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeInputManager : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public GameObject incorrectInputText;
    public string correctCode = "1234"; // Set your correct code here
    private string currentInput = "";

    public LightHandler lightHandler;

    public GameObject objectToDeactive;

    void Start()
    {
        inputText.text = "Enter the Code: " + correctCode;
        incorrectInputText.SetActive(false);
    }

    public void ButtonClick(int number)
    {
        if (currentInput.Length < correctCode.Length)
        {
            currentInput += number.ToString();
            inputText.text = currentInput;
        }

        if (currentInput.Length == correctCode.Length)
        {
            CheckCode();
        }

        incorrectInputText.SetActive(false);
    }

    public void ClearInput()
    {
        currentInput = "";
        inputText.text = currentInput;
    }

    private void CheckCode()
    {
        if (currentInput == correctCode)
        {
            // Code is correct, you can add your success logic here
            Debug.Log("Code is correct!");
            //lightHandler.PuzzleComplete();
            gameObject.SetActive(false);
        }
        else
        {
            // Code is incorrect, you can add your failure logic here
            Debug.Log("Code is incorrect. Try again.");
            incorrectInputText.SetActive(true);
            ClearInput();
        }
    }
}

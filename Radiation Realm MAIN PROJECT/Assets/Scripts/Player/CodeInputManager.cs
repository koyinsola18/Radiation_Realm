using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeInputManager : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public GameObject incorrectInputText;
    public string correctCode = ""; // Set your correct code here
    private string currentInput = "";

    public LightHandler lightHandler;

    public GameObject objectToDeactive;

    public AudioSource audioSource;
    public AudioClip[] clip;

    public AudioSource handlerAudio;

    void Start()
    {
        inputText.text = "Enter the 4 Digit Code: ";
        incorrectInputText.SetActive(false);
    }

    public void ButtonClick(int number)
    {
        audioSource.PlayOneShot(clip[0]);
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
            handlerAudio.PlayOneShot(clip[1]);
            Debug.Log("Code is correct!");
            //lightHandler.PuzzleComplete();
            gameObject.SetActive(false);
            objectToDeactive.SetActive(false);
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

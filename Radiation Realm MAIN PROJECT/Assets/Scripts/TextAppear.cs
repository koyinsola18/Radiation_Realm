using UnityEngine;
using TMPro;
using System.Collections;

public class TextAppear : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public float letterDelay = 0.05f;

    private string fullText;
    private string currentText = "";

    private void Start()
    {
        // Get the full text from the TextMeshProUGUI component
        fullText = instructionText.text;

        // Clear the text to start the animation
        instructionText.text = "";

        // Start the coroutine to show text letter by letter
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        // Check for the Space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If Space key is pressed, instantly reveal the entire text
            StopAllCoroutines();
            instructionText.text = fullText;
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i];
            instructionText.text = currentText;

            yield return new WaitForSeconds(letterDelay);
        }
    }
}


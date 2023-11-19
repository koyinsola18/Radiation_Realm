using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this for UI-related functionality

public class DragandDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;
    public float Dropdistance;
    public bool isLocked;
    public bool allPiecesInCorrectPositions = false;

    public AudioSource audioSource;
    public AudioClip clip;

    public GunBuilder builder;

    Vector2 objectInitPos;

    public Text congratulationText; // Reference to the Text element

    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if (Distance < Dropdistance)
        {
            isLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            audioSource.PlayOneShot(clip);
            CheckPuzzleCompletion();
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }

    private void CheckPuzzleCompletion()
    {
        GameObject[] puzzlePieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        allPiecesInCorrectPositions = true;

        foreach (GameObject puzzlePiece in puzzlePieces)
        {
            DragandDrop dragAndDropScript = puzzlePiece.GetComponent<DragandDrop>();

            if (!dragAndDropScript.isLocked)
            {
                allPiecesInCorrectPositions = false;
                break;
            }
        }

        if (allPiecesInCorrectPositions)
        {
            ShowCongratulationMessage();
        }
    }

    private void ShowCongratulationMessage()
    {
        builder.PuzzleComplete();
    }
}

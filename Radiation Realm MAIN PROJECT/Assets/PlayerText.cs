using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    [SerializeField] GameObject playerThought;
    public TextMeshProUGUI text;

    public float timeForText;

    [TextArea(4, 15)]
    public string sentence;

    void Awake()
    {
        //text.text = sentence;
    }

    void OnTriggerEnter2D()
    {
        text.text = sentence;
        playerThought.SetActive(true);

    }

    void OnTriggerExit2D()
    {
        StartCoroutine(OffAfterCertainTime());
    }

    IEnumerator OffAfterCertainTime()
    {
        yield return new WaitForSeconds(timeForText);
        playerThought.SetActive(false);
    }

}

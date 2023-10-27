using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject radiationBar;

    void Start()
    {
        loadingScreen.SetActive(false);
    }
    void OnTriggerEnter2D()
    {
        radiationBar.SetActive(false);
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Level_2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneHandler : MonoBehaviour
{
    [SerializeField] string[] sceneNames;
    [SerializeField] GameObject loadingScreen;
    
    void Start()
    {
        loadingScreen.SetActive(false);      
    }
    
    public void LoadStartLevel()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneNames[0]);
    }
}

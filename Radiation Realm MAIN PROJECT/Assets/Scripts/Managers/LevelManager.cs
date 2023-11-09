using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject radiationBar;

    // Public variable to set the scene name in the Unity Inspector
    public string sceneToLoad;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            radiationBar.SetActive(false);
            loadingScreen.SetActive(true);

            // Call the LoadScene method with the specified scene name
            LoadScene(sceneToLoad);
        }
    }

    // This is the LoadScene method outside of the OnTriggerEnter2D
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

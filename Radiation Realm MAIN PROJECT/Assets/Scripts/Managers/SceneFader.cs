using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    IEnumerator FadeOut(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);

        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}

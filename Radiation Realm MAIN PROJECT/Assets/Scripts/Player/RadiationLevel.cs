using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadiationLevel : MonoBehaviour
{
    public DeathManager deathManager;

    public TextMeshProUGUI radiationLevelText;
    public Image RadiationBar;

    public float radiationLevelMultiplier = 2f; // How fast the bar will go up

    public float radiationLevel;
    float maxLevel = 100.00f;
    float lerpSpeed;

    public GameObject bar;
    public GameObject barText;

    public GameObject HurtCanvas;
    private static RadiationLevel instance;

    public GameObject player;

    void Start()
    {
        gameObject.SetActive(true);
        // Load the radiation level from PlayerPrefs
        radiationLevel = PlayerPrefs.GetFloat("RadiationLevel", 0f);
        // Check if the loaded radiation level is over maxLevel
        if (radiationLevel > maxLevel)
        {
            // Set radiationLevel to maxLevel or some other appropriate value
            radiationLevel = maxLevel;
        }
        HurtCanvas.SetActive(false);
    }
    public void ResetRadiation()
    {
        radiationLevel = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        radiationLevelText.text = "Radiation: " + radiationLevel.ToString("F2") + "%";

        if (radiationLevel < maxLevel)
        {
            radiationLevel += radiationLevelMultiplier * Time.deltaTime;
        }
        else
        {
            if (!deathManager.isDead)
            {
                deathManager.Die();
                bar.SetActive(false);
                barText.SetActive(false);
                // Do not deactivate the player if you want it to persist across scenes
                // player.SetActive(false);
            }
        }

        RadiationBar.fillAmount = radiationLevel / maxLevel;
        RadiationBar.fillAmount = Mathf.Lerp(RadiationBar.fillAmount, radiationLevel / maxLevel, lerpSpeed);

        lerpSpeed = 3f * Time.deltaTime;

        ColorChanger();

        // Save the radiation level to PlayerPrefs
        PlayerPrefs.SetFloat("RadiationLevel", radiationLevel);
        // Save all changes to disk
        PlayerPrefs.Save();
    }

    void ColorChanger()
    {
        Color radiationBarColor = Color.Lerp(Color.green, Color.red, (radiationLevel / maxLevel));
        RadiationBar.color = radiationBarColor;
    }

    public void RadiationDamage(float damageAmount)
    {
        if (radiationLevel < 100f)
        {
            radiationLevel += damageAmount;
            HurtCanvas.SetActive(true);
        }
    }

    public void RadiationHeal(float damageAmount)
    {
        if (radiationLevel < 100f && radiationLevel > 0f)
        {
            radiationLevel -= damageAmount;
        }
    }

    private void OnDestroy()
    {
        // Ensure the radiation level is saved when the object is destroyed
        PlayerPrefs.SetFloat("RadiationLevel", radiationLevel);
        // Save all changes to disk
        PlayerPrefs.Save();
    }
}

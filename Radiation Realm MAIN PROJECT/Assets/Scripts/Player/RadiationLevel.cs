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

    float radiationLevel, maxLevel = 100.00f;
    float lerpSpeed;

    public GameObject bar;
    public GameObject barText;


    public GameObject HurtCanvas;
    private static RadiationLevel instance;

    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */

    void Start()
    {
        gameObject.SetActive(true);
        radiationLevel = 0f;
        HurtCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        radiationLevelText.text = "Radiation: " + radiationLevel.ToString("F2") + "%";

        if(radiationLevel <= maxLevel)
        {
            radiationLevel += radiationLevelMultiplier * Time.deltaTime;
        }
        else
        {
            deathManager.Die();
            bar.SetActive(false);
            barText.SetActive(false);
        }


        RadiationBar.fillAmount = radiationLevel/ maxLevel;
        RadiationBar.fillAmount = Mathf.Lerp(RadiationBar.fillAmount, radiationLevel / maxLevel, lerpSpeed);

        lerpSpeed = 3f* Time.deltaTime;

        ColorChanger();
        
    }

    void ColorChanger()
    {
        Color radiationBarColor = Color.Lerp(Color.green, Color.red, (radiationLevel / maxLevel));
        RadiationBar.color = radiationBarColor;
    }

    public void RadiationDamage(float damageAmount)
    {
        if(radiationLevel < 100f)
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
}

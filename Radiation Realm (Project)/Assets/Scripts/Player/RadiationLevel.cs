using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadiationLevel : MonoBehaviour
{
    public TextMeshProUGUI radiationLevelText;
    public Image RadiationBar;

    public float radiationLevelMultiplier = 2f; // How fast the bar will go up

    float radiationLevel, maxLevel = 100f;
    float lerpSpeed;





    void Start()
    {
        radiationLevel = maxLevel;
        
    }

    // Update is called once per frame
    void Update()
    {
        radiationLevelText.text = "Radiation Level: " + radiationLevel.ToString("F2") + "%";

        if(radiationLevel <= maxLevel)
        {
            radiationLevel -= radiationLevelMultiplier * Time.deltaTime;
        }
        

        RadiationBar.fillAmount = radiationLevel/ maxLevel;
        RadiationBar.fillAmount = Mathf.Lerp(RadiationBar.fillAmount, radiationLevel / maxLevel, lerpSpeed);

        lerpSpeed = 3f* Time.deltaTime;

        ColorChanger();
        
    }

    void ColorChanger()
    {
        Color radiationBarColor = Color.Lerp(Color.red, Color.green, (radiationLevel / maxLevel));
        RadiationBar.color = radiationBarColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreen;
    public TextMeshProUGUI countdownText;
    public float respawnDelay = 5f;

    private bool isDead = false;

    private void Start()
    {
        deathScreen.SetActive(false);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            StartCoroutine(RespawnCountdown());
        }
    }

    IEnumerator RespawnCountdown()
    {
        deathScreen.SetActive(true);

        for (int i = (int)respawnDelay; i > 0; i--)
        {
            countdownText.text = "Respawning in " + i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Respawning in 1";

        yield return new WaitForSeconds(1f);

        // Respawn logic here
        // You can reload the scene or move the player to the starting position

        // For example, to reload the scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Or to move the player to a starting position:
        // transform.position = startingPosition;

        // Deactivate the death screen
        deathScreen.SetActive(false);
        isDead = false;
    }
}

using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 3;
    internal int currentHealth;
    private AudioManager audioManager;
    public TMP_Text UIText;
    private bool canLoseHealth = true;
    public GameObject deathScreen;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        UIText.text = health.ToString();
    }

    public void loseHealth()
    {
        if (canLoseHealth)
        {
            if (health <= 1)
            {
                // Player has died
                // death screen shows prompting restart or quit
                GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;

                // Play death sound effect
                audioManager.PlaySFX(audioManager.death);
                deathScreen.SetActive(true);
                audioManager.PlaySFX(audioManager.gameover);
            }
            else
            {
                // Player lost health but is still alive
                health--;
                print("Kill");
                UIText.text = health.ToString();
            }

            canLoseHealth = false;
            StartCoroutine(EnableLoseHealth());
        }
    }

    IEnumerator EnableLoseHealth()
    {
        yield return new WaitForSeconds(0.5f);
        canLoseHealth = true;
    }
}

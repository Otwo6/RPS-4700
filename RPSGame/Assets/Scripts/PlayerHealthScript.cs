using UnityEngine;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 3;
    internal int currentHealth;
    private AudioManager audioManager;
    public TMP_Text UIText;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void loseHealth()
    {
        if (health <= 0)
        {
            // Player has died
            // death screen shows prompting restart or quit
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;

            // Play death sound effect
            audioManager.PlaySFX(audioManager.death);
            UIText.text = health.ToString();
        }
        else
        {
            // Player lost health but is still alive
            health--;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 3;
    internal int currentHealth;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void loseHealth()
    {
        if (health <= 0)
        {
            // death screen shows prompting restart or quit
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;
            
            // Play death sound effect
            audioManager.PlaySFX(audioManager.death);
        }
        else
        {
            health--;
        }
    }
}

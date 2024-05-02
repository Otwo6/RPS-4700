using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrItemScript : MonoBehaviour
{
    public int currentItem = 0; // 0 is Rock, 1 is Paper, 2 is Scissors

    public bool canAttack = true;

    [SerializeField] Animator animator;
    [SerializeField] GameObject rockCollision;
    [SerializeField] GameObject scissorsCollision;
    [SerializeField] GameObject paperPlane;

    private AudioManager audioManager; // Reference to AudioManager

    private void Awake()
    {
        // Find and assign AudioManager component
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // Switch item with numbers
        if (Input.GetKeyDown("1"))
        {
            print("Using Rock");
            currentItem = 0;
            audioManager.PlaySFX(audioManager.equip); // Play equip sound
        }

        if (Input.GetKeyDown("2"))
        {
            print("Using Paper");
            currentItem = 1;
            audioManager.PlaySFX(audioManager.equip); // Play equip sound
        }

        if (Input.GetKeyDown("3"))
        {
            print("Using Scissors");
            currentItem = 2;
            audioManager.PlaySFX(audioManager.equip); // Play equip sound
        }

        // Cycle through items
        if (Input.GetButtonDown("NextItem"))
        {
            if (currentItem == 2)
            {
                currentItem = 0;
            }
            else
            {
                currentItem++;
            }
            audioManager.PlaySFX(audioManager.equip); // Play equip sound
        }

        // Attack
        if (Input.GetButtonDown("Attack") && canAttack)
        {
            if (currentItem == 0) // If Rock
            {
                // Play rock sound effect
                audioManager.PlaySFX(audioManager.Rockattack);
                animator.Play("ToyKnightRockSlam");
            }
            else if (currentItem == 1) // If Paper
            {
                // Play paper sound effect
                audioManager.PlaySFX(audioManager.Paperattack);
                animator.Play("ToyKnightThrowPlane");
            }
            else if (currentItem == 2) // If Scissors
            {
                // Play scissors sound effect
                audioManager.PlaySFX(audioManager.Scissorattack);
                animator.Play("ToyKnightChopScissors");
            }
        }
    }

    public void SpawnPlane()
    {
        Instantiate(paperPlane, transform.position + transform.forward * 0.5f + transform.right * 0.75f, transform.rotation);
    }
}
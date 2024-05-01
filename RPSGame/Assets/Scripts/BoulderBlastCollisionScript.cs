using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBlastCollisionScript : MonoBehaviour
{
	public float knockback = 15.0f;
	AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerMovement playerMove = col.gameObject.GetComponent<PlayerMovement>();
            if(playerMove != null)
            {
                    print("Ouchy");

	    		// Launch player
                playerMove.rb.velocity = new Vector3(playerMove.rb.velocity.x, 0f, playerMove.rb.velocity.z);
                playerMove.rb.AddForce(playerMove.transform.up * playerMove.jumpForce, ForceMode.Impulse);
                playerMove.rb.AddForce(transform.forward * knockback, ForceMode.Impulse);

	    		// Damage health or kill
		    	PlayerHealthScript playerHealth = col.gameObject.GetComponent<PlayerHealthScript>();
			    playerHealth.loseHealth();
                // Play the enemy hit sound effect
                audioManager.PlaySFX(audioManager.enemyhit);

            }
			Destroy(gameObject);
        }
    }
}

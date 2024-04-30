using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Vector3 guardingSpot;
    public float knockback = 15.0f;
    public bool chasing = false;
    public GameObject player;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        guardingSpot = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (chasing)
        {
            agent.SetDestination(player.transform.position);
        }
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
			    playerHealth.health--;
    			if(playerHealth.health <= 0)
	    		{
		    		print("Dead");
    			}
                // Play the enemy hit sound effect
                audioManager.PlaySFX(audioManager.enemyhit);

            }
        }
    }
}

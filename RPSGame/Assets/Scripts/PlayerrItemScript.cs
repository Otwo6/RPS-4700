using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrItemScript : MonoBehaviour
{
	public int currentItem = 0; // 0 is Rock, 1 is Paper, 2 is Scissors

	public bool canAttack = true;

	float attackDelayTime = 0.2f;
	float attackCurrentTime = 0.0f;

	[SerializeField] Animator animator;

	[Header("Collision Boxes")]
	
	[SerializeField] GameObject rockCollision;
	[SerializeField] GameObject scissorsCollision;
	[SerializeField] GameObject paperPlane;

	void Update()
	{
		// Switch item with numbers
		if(Input.GetKeyDown("1"))
		{
			print("Using Rock");
			currentItem = 0;
		}
		
		if(Input.GetKeyDown("2"))
		{
			print("Using Paper");
			currentItem = 1;
		}

		if(Input.GetKeyDown("3"))
		{
			print("Using Scissors");
			currentItem = 2;
		}

		// Cycle through items
		if(Input.GetButtonDown("NextItem"))
		{
			if(currentItem == 2)
			{
				currentItem = 0;
			}
			else
			{
				currentItem++;
			}
		}

		// Attack
		if(Input.GetButtonDown("Attack") && canAttack)
		{
			if(currentItem == 0) // If Rock
			{
				// Do all this in an animation event whhere you can enable trigger at set time then disable at set time
				/**rockCollision.SetActive(true);
				canAttack = false;**/
				animator.Play("ToyKnightRockSlam");

			}
			else if(currentItem == 1) // If Paper
			{
				animator.Play("ToyKnightThrowPlane");
			}
			else if(currentItem == 2) // If Scissors
			{
				animator.Play("ToyKnightChopScissors");
			}
		}
	}

	public void SpawnPlane()
	{
		Instantiate(paperPlane, transform.position + transform.forward * 0.5f + transform.right * 0.75f, transform.rotation);
	}
}

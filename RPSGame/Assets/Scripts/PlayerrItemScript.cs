using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrItemScript : MonoBehaviour
{
	public int currentItem = 0; // 0 is Rock, 1 is Paper, 2 is Scissors

	public bool canAttack = true;

	float attackDelayTime = 0.2f;
	float attackCurrentTime = 0.0f;

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
				rockCollision.SetActive(true);
				canAttack = false;
			}
			else if(currentItem == 1) // If Paper
			{
		        Instantiate(paperPlane, transform.position + transform.up * 1.5f, transform.rotation);
			}
			else if(currentItem == 2) // If Scissors
			{
				scissorsCollision.SetActive(true);
				canAttack = false;
			}
		}

		if(!canAttack)
		{
			if(attackCurrentTime < attackDelayTime)
			{
				attackCurrentTime += Time.deltaTime;
			}
			else
			{
				canAttack = true;
				attackCurrentTime = 0.0f;
				rockCollision.SetActive(false);
				scissorsCollision.SetActive(false);
			}
		}
	}
}

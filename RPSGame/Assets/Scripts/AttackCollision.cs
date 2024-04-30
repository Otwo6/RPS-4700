using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			print("Please work");
			EnemyHealthScript enemyHealth = col.gameObject.GetComponent<EnemyHealthScript>();
			if(enemyHealth != null && enemyHealth.health > 0)
			{
				enemyHealth.health--;
			}
			else
			{
				Destroy(col.gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			print("Please work");
			EnemyHealthScript enemyHealth = col.gameObject.GetComponent<EnemyHealthScript>();
			if(enemyHealth != null && enemyHealth.health > 0)
			{
				enemyHealth.health--;
			}
			else
			{
				Destroy(col.gameObject);
			}
		}
	}
}

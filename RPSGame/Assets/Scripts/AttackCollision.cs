using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Debug.Log("Please work");
			EnemyHealthScript enemyHealth = col.gameObject.GetComponent<EnemyHealthScript>();
			
			Paperling paperling = col.gameObject.GetComponent<Paperling>();

			if(paperling != null)
			{
				if(paperling.size == 2)
				{
					paperling.split(paperling.mediumPaperlingPrefab, 2);
					Destroy(col.gameObject);

				}
				else if(paperling.size == 1)
				{
					paperling.split(paperling.smallPaperlingPrefab, 1);
					Destroy(col.gameObject);

				}
				else
				{
					Destroy(col.gameObject);
				}
			}
			else if(enemyHealth != null && enemyHealth.health > 0)
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
			Debug.Log("Please work");
			EnemyHealthScript enemyHealth = col.gameObject.GetComponent<EnemyHealthScript>();
			
			Paperling paperling = col.gameObject.GetComponent<Paperling>();

			if(paperling != null)
			{
				if(paperling.size == 2)
				{
					paperling.split(paperling.mediumPaperlingPrefab, 2);
					Destroy(col.gameObject);

				}
				else if(paperling.size == 1)
				{
					paperling.split(paperling.smallPaperlingPrefab, 1);
					Destroy(col.gameObject);

				}
				else
				{
					Destroy(col.gameObject);
				}
			}
			else if(enemyHealth != null && enemyHealth.health > 0)
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

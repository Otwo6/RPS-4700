using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightScript : MonoBehaviour
{
	[SerializeField] EnemyScript enemyScript;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			// Chase Player
			enemyScript.player = col.gameObject;
			print("overlap");
			enemyScript.chasing = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			// Go to guarding spot
			enemyScript.chasing = false;
			enemyScript.agent.SetDestination(enemyScript.guardingSpot);
		}
	}
}

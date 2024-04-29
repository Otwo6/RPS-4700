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
			Destroy(col.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			print("Please work");
			Destroy(col.gameObject);
		}
	}
}

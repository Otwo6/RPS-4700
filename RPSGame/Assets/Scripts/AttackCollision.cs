using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(col.gameObject);
		}
	}
}

using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
	public float speed = 5f;

	void Update()
	{
		// Move the projectile straight
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag != "Player")
		{
			print("Destroyed breh");
			Destroy(gameObject);
		}
	}
}

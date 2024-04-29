using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 5f;
    public float selfDestructDelay = 4f; // Time before the projectile self-destructs

    void Start()
    {
        // Destroy the projectile after the specified delay
        Destroy(gameObject, selfDestructDelay);
    }

    void Update()
    {
        // Move the projectile straight
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            print("Destroyed breh");
            Destroy(gameObject);
        }
    }
}

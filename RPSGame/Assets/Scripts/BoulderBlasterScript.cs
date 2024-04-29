using UnityEngine;

public class BoulderBlasterScript : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public float shootInterval = 2f; // Time interval between shots
    public float rotationSpeed = 2f; // Speed of rotation towards the player

    private float timeSinceLastShot; // Timer to track time since the last shot

    void Start()
    {
        // Start the timer at 0
        timeSinceLastShot = 0f;
    }

    void Update()
    {
        // If player is null, return (no player reference)
        if (player == null)
            return;

        // Rotate towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Count time since the last shot
        timeSinceLastShot += Time.deltaTime;

        // If enough time has passed, shoot
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            // Reset the timer
            timeSinceLastShot = 0f;
        }
    }

    void Shoot()
    {
        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
        // Optionally, you can set the projectile's velocity or behavior here
    }
}

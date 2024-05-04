using UnityEngine;

public class BoulderBlasterScript : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public float shootInterval = 2f; // Time interval between shots
    public float rotationSpeed = 2f; // Speed of rotation towards the player
    public float lineOfSightRadius = 10f; // Radius within which to check line of sight

    private float timeSinceLastShot; // Timer to track time since the last shot
    private AudioManager audioManager; // Reference to the AudioManager

    void Awake()
    {
        // Find and assign the AudioManager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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

        // Check if the player is within the line of sight radius
        if (Vector3.Distance(transform.position, player.position) <= lineOfSightRadius)
        {
            // Perform line trace to check for obstacles
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, lineOfSightRadius))
            {
                // If the line trace hits something other than the player, don't shoot
                if (hit.collider.gameObject != player.gameObject)
                {
                    return;
                }
            }

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
    }

    void Shoot()
    {
        // Play shoot sound effect
        audioManager.PlaySFX(audioManager.BoulderBlasterShoot);

        // Instantiate the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward * 2.5f, transform.rotation);
        // Optionally, you can set the projectile's velocity or behavior here
    }
}
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    AudioManager audioManager;
    private Vector3 spawnLocation; // Store the spawn location
    private bool isRespawning = false; // Flag to check if the player is respawning

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Set the initial spawn location to the player's starting position
        spawnLocation = transform.position;
    }

    public void SetSpawnLocation(Vector3 location)
    {
        // Set the spawn location to the specified location
        spawnLocation = location;
    }

    public void Respawn()
    {
        // Check if the player is respawning
        if (!isRespawning)
        {
            // Play the respawn audio
            audioManager.PlaySFX(audioManager.respawn);
        }

        // Respawn the player at the spawn location
        transform.position = spawnLocation;

        // Set the flag to true to indicate the player is respawning
        isRespawning = true;
    }

    // Method to reset the respawn flag (call this when the respawn animation/audio is finished)
    public void ResetRespawnFlag()
    {
        isRespawning = false;
    }
}
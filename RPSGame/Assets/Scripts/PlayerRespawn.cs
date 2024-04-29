using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 spawnLocation; // Store the spawn location

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
        // Respawn the player at the spawn location
        transform.position = spawnLocation;
    }
}

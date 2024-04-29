using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public float spawnInterval = 1f; // Time between spawns
    public int spawnCount = 5; // Number of spawns

    private int spawnCounter = 0;
    private float timer = 0f;
    private bool isSpawning = false;

    void Update()
    {
        if (isSpawning)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        if (spawnCounter < spawnCount)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            spawnCounter++;
        }
        else
        {
            StopSpawning();
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        spawnCounter = 0;
        timer = 0f;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}

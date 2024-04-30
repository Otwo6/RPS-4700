using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperling : MonoBehaviour
{
    public GameObject mediumPaperlingPrefab;
    public GameObject smallPaperlingPrefab;
   
    public int size;
    public void split(GameObject prefab, int size)
{
    if (size > 0)
    {
        for (int i = 0; i < 2; i++)
        {
            float direction = i == 0 ? -1f : 1f; // Direction for left (-1) and right (1)
            Vector3 spawnOffset = transform.right * direction * 2f; // Calculate spawn offset
            Vector3 spawnPosition = transform.position + spawnOffset;
            GameObject newPaperling = Instantiate(prefab, spawnPosition, Quaternion.identity);
            print("spawned");
            Paperling newPaperlingScript = newPaperling.GetComponent<Paperling>();
            if (newPaperlingScript != null)
            {
                newPaperlingScript.size = size - 1;
            }
        }
    }
}

}

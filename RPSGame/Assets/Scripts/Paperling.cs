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
            for(int i = 0; i < 2; i++)
            {
                float xOffset = i == 0 ? -2f : 2f; // If i is 0, spawn to the left (-5f), else spawn to the right (5f)
                Vector3 spawnPosition = transform.position + new Vector3(xOffset, 0f, Random.Range(-1f, 1f));
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

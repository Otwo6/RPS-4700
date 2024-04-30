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
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                GameObject newPaperling = Instantiate(prefab, spawnPosition, Quaternion.identity);
                Paperling newPaperlingScript = newPaperling.GetComponent<Paperling>();
                if (newPaperlingScript != null) {
                    newPaperlingScript.size = size - 1;
                }
            }
        }
    }
}

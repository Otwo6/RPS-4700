using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
	public ObjectSpawner[] spawners;
	bool done = false;

    void OnTriggerEnter(Collider other)
    {
		if(!done)
		{
			if (other.CompareTag("Player")) // You can adjust the tag as needed
        	{
				print("Spawning");
	            done = true;
				foreach (ObjectSpawner spawner in spawners)
            	{
        	        spawner.StartSpawning();
    	        }
	        }
		}
    }
}

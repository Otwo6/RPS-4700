using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject objectToActivate;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paper Plane"))
        {
            // Destroy this object
            Destroy(gameObject);

            // Set another GameObject active
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}

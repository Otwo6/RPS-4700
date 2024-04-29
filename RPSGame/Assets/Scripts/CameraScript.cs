using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float camHeight = 1.5f;
    [SerializeField] float camDistance = 7.0f;
    [SerializeField] float minX = -10f; // Define minimum x position
    [SerializeField] float maxX = 10f; // Define maximum x position

    void FixedUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(player.transform.position.x, minX, maxX), // Limit x position
            player.transform.position.y + camHeight,
            player.transform.position.z - camDistance
        );

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
    }
}

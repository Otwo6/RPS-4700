using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
	[SerializeField] float camHeight = 1.5f;
	[SerializeField] float camDistance = 7.0f;

    void FixedUpdate()
    {
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + camHeight, player.transform.position.z - camDistance), 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrooperRotationScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] GameObject mesh;
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void FixedUpdate()
    {
        if(agent.velocity.magnitude > 0.5f)
        {
            mesh.transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}

using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public Vector3 targetA;
    public Vector3 targetB;
    public float moveTime = 2f; // Time taken to move from the start to end position
    private float elapsedTime = 0f;
    private bool movingToB = true; // Start by moving towards target B
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the fraction of movement completed
        float t = Mathf.Clamp01(elapsedTime / moveTime);

        // Move the object towards target A or B depending on the current state
        if (movingToB)
        {
            transform.position = Vector3.Lerp(startPosition + targetA, startPosition + targetB, t);
        }
        else
        {
            transform.position = Vector3.Lerp(startPosition + targetB, startPosition + targetA, t);
        }

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // If movement is complete, swap targets and reset timer
        if (t >= 1f)
        {
            movingToB = !movingToB;
            elapsedTime = 0f;
        }
    }
}

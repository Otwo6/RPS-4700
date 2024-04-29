using UnityEngine;

public class SwingingObstacle : MonoBehaviour
{
    public float swingAngle = 45f; // The maximum angle of swing
    public float swingSpeed = 1f; // The speed of swing

    private Quaternion startRotation;
    private Quaternion endRotation;
    private float t = 0f;
    private bool forward = true;

    void Start()
    {
        startRotation = Quaternion.Euler(0, 0, -swingAngle / 2);
        endRotation = Quaternion.Euler(0, 0, swingAngle / 2);
    }

    void Update()
    {
        if (forward)
        {
            t += Time.deltaTime * swingSpeed;
            if (t >= 1.0f)
            {
                t = 1.0f;
                forward = false;
            }
        }
        else
        {
            t -= Time.deltaTime * swingSpeed;
            if (t <= 0.0f)
            {
                t = 0.0f;
                forward = true;
            }
        }

        transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
    }
}
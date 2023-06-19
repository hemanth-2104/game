using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector2 startPos;
    private float startTime;
    private Rigidbody rb;
    
    [SerializeField] private float swipeForceMultiplier = 5f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    startTime = Time.time;
                    break;

                case TouchPhase.Ended:
                    Vector2 endPos = touch.position;
                    float swipeTime = Time.time - startTime;
                    float swipeDistance = Vector2.Distance(startPos, endPos);
                    
                    // Calculate swipe direction and force
                    Vector2 swipeDirection = endPos - startPos;
                    float swipeForce = swipeDistance / swipeTime * swipeForceMultiplier;

                    // Apply the calculated force to the ball
                    rb.AddForce(swipeDirection.normalized * swipeForce, ForceMode.Impulse);
                    break;
            }
        }
    }
}

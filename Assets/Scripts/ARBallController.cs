using UnityEngine;

public class ARBallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ARGameManager.instance.currentAttempt < ARGameManager.instance.maxAttempts)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * CalculateSwipeForce(), ForceMode.Impulse);
    }

    private float CalculateSwipeForce()
    {
        // Calculate swipe force based on swipe input (mouse or touch)
        // Return the appropriate force value based on your desired gameplay

        return 10f; // Example force value
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            ARGameManager.instance.IncrementScore();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        if (ARGameManager.instance.currentAttempt < ARGameManager.instance.maxAttempts)
        {
            ARGameManager.instance.currentAttempt++;
            Invoke("ResetBallPosition", 5f);
        }
        else
        {
            ARGameManager.instance.retryButton.SetActive(true);
        }
    }

    private void ResetBallPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

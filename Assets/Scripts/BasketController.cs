using UnityEngine;

public class BasketController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Handle scoring logic here
        }
    }
}

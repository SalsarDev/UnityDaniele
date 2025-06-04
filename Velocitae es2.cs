using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity *= 2f;
            Debug.Log("Portale attivato! Velocità raddoppiata!");
        }
    }
}
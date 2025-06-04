using UnityEngine;

public class ObstacleCourse : MonoBehaviour
{
    public Transform startPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPoint.position;
            Debug.Log("Hai toccato un ostacolo!");
        }
        else if (collision.gameObject.CompareTag("Pathfinito"))
        {
            Debug.Log("Hai Vinto!");
        }
    }
}
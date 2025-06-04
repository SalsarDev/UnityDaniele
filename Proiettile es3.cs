using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    public Transform cameraTransform;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * rotate);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * 500f, ForceMode.Impulse);
            Destroy(proj, 5f);
        }
    }
}
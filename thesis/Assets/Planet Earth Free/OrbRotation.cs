using UnityEngine;

public class OrbRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the orb based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, -mouseY * rotationSpeed * Time.deltaTime, Space.World);
    }
}

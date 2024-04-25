using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Get input from arrow keys or WASD keys for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float upDownInput = Input.GetAxis("Jump"); // Use Jump axis for moving up and down
        Debug.Log("UpDownInput: " + upDownInput); // Add this line

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, upDownInput, verticalInput) * moveSpeed * Time.deltaTime;

        // Move the object
        transform.Translate(movement, Space.World);

        // Get input from mouse or touch for rotation
        float rotationInput = Input.GetAxis("Mouse X");

        // Rotate the object around its vertical axis
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }
}

using UnityEngine;

// Moves to trigger the transition to the next Tutorial panel when the panel is moved 
public class Tutorial_MoveToGetNextPanel : MonoBehaviour
{
    public Tutorial_PanelController panelController; // Reference to the PanelController script
    private Vector3 initialPosition; // Initial position of the panel
    private bool hasMoved = false; // Flag to track movement

    void Start()
    {
        // Record the initial position of the panel
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check if the panel has moved since the last frame
        if (Vector3.Distance(transform.position, initialPosition) > 0.03f)
        {
            // Toggle panels only if the object has moved
            if (!hasMoved)
            {
                TogglePanels();
                hasMoved = true; // Set moved flag to true
            }

            // Update the initial position for the next frame
            initialPosition = transform.position;
        }
        else
        {
            hasMoved = false; // Reset moved flag if the object returns to the initial position
        }
    }

    // Method to toggle panels and move to the next panel
    public void TogglePanels()
    {
        if (panelController != null)
        {
            initialPosition = transform.position;
            panelController.ShowNextPanel(); // Show the next panel
        }
    }
}

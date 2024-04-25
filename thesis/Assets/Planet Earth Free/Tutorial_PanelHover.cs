using UnityEngine;

// Ensures the panel is hovered over before ShowNextPanel() is called
public class Tutorial_PanelHover : MonoBehaviour
{
    public Tutorial_PanelController panelController; // Reference to the PanelController script
    public GameObject Gif;

    private bool isHovering = false;

    private void Start()
    {
        Gif.SetActive(false);
    }

    // Triggered when hovering starts
    public void StartHovering()
    {
        isHovering = true;
        StartCoroutine(WaitForHover());
        Gif.SetActive(true);
    }

    // Triggered when hovering stops
    public void StopHovering()
    {
        isHovering = false;
        Gif.SetActive(false);
    }

    // Coroutine to wait for a specified hover time before triggering an action
    System.Collections.IEnumerator WaitForHover()
    {
        float hoverTime = 0f;
        while (isHovering && hoverTime < 5f) // Change 5f to the desired hover time
        {
            hoverTime += Time.deltaTime;
            yield return null;

            // Perform actions after 5 seconds of hovering here
            if (hoverTime > 4f)
            {
                panelController.ShowNextPanel(); // Calls the ShowNextPanel method after the specified time
            }
        }
    }
}

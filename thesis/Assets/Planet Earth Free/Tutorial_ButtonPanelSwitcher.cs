using UnityEngine;

// Makes sure both buttons are clicked before ShowNextPanel() is called 
public class Tutorial_ButtonPanelSwitcher : MonoBehaviour
{
    public Tutorial_PanelController panelController; // Reference to the PanelController script
    
    public GameObject object1; // Reference to the first  Tutorial checkbox
    public GameObject object2; // Reference to the second Tutorial checkbox

    public GameObject button1; // Reference to GameObject for Tutorial button 1
    public GameObject button2; // Reference to GameObject for Tutorial button 2

    private bool object1Active = false;
    private bool object2Active = false;

    void Start()
    {
        // Deactivate both objects at the start of the scene
        if (object1 != null)
            object1.SetActive(false);

        if (object2 != null)
            object2.SetActive(false);

        if (button1 != null)
            button1.SetActive(true);

        if (button2 != null)
            button2.SetActive(true);

       
    }

    public void OnButton1Clicked() //toggles between the Button and the Checkbox's visbality
    {
        object1.SetActive(true);
        button1.SetActive(false);
        

        CheckPanelVisibility();
    }

    public void OnButton2Clicked() //toggles between the Button and the Checkbox's visbality
    {
        object2.SetActive(true);
      
        button2.SetActive(false);
        

        CheckPanelVisibility();
    }

    private void CheckPanelVisibility() // makes sure that both buttons are clciked before moving forward in the tutorial
    {
        if (!button1.activeSelf && !button2.activeSelf)
        {
            
                WhenClicked();
            //resets all the components for when/if the tutorial is repeated 
                object1.SetActive(false);
                button1.SetActive(true);
                object2.SetActive(false);
                button2.SetActive(true);
            
        }
    }
    public void WhenClicked()
    {
        if (panelController != null)
        {
            panelController.ShowNextPanel(); // Show the next panel
        }
   
    }


}

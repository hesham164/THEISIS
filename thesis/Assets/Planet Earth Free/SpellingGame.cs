using UnityEngine;
using UnityEngine.UI;

public class SpellingGame : MonoBehaviour
{
    [SerializeField] private Transform[] buttonPlates;
    [SerializeField] private Transform[] correctButtons;
    [SerializeField] private Transform[] incorrectButtons;

    private int currentButtonPlateIndex = 0;

    private void Start()
    {
        // Initialize buttons on the first button plate
        InitializeButtons(buttonPlates[currentButtonPlateIndex], correctButtons);
        InitializeButtons(buttonPlates[currentButtonPlateIndex], incorrectButtons);

        // Activate the first button plate and deactivate others
        for (int i = 0; i < buttonPlates.Length; i++)
        {
            buttonPlates[i].gameObject.SetActive(i == currentButtonPlateIndex);
        }
    }

    private void InitializeButtons(Transform buttonPlate, Transform[] buttons)
    {
        // Iterate over each button in the button plate
        for (int i = 0; i < buttonPlate.childCount; i++)
        {
            // Assign the button transforms to the array
            buttons[i] = buttonPlate.GetChild(i);
            // Add a click event listener to each button
            int buttonIndex = i; // Store the current index to avoid closure issues
            buttons[i].GetComponent<Button>().onClick.AddListener(() => WhenButtonClicked(buttonIndex));
        }
    }

    public void WhenButtonClicked(int buttonIndex)
    {
        // Toggle to the next button plate
        currentButtonPlateIndex = (currentButtonPlateIndex + 1) % buttonPlates.Length;

        // Initialize buttons on the new button plate
        InitializeButtons(buttonPlates[currentButtonPlateIndex], correctButtons);
        InitializeButtons(buttonPlates[currentButtonPlateIndex], incorrectButtons);

        // Activate the current button plate and deactivate others
        for (int i = 0; i < buttonPlates.Length; i++)
        {
            buttonPlates[i].gameObject.SetActive(i == currentButtonPlateIndex);
        }

        // Check if the clicked button is the correct answer
        if (buttonIndex == 0)
        {
            Debug.Log("Correct answer!");
            // Change the color of the correct button
            correctButtons[buttonIndex].GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Wrong answer!");
            // Change the color of the wrong button
            incorrectButtons[buttonIndex].GetComponent<Image>().color = Color.red;
        }

        // Disable all buttons to prevent further clicks
        foreach (Transform button in correctButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        foreach (Transform button in incorrectButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}

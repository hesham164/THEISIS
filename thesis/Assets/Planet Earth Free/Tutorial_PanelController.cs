using UnityEngine;
using TMPro;

public class Tutorial_PanelController : MonoBehaviour
{
    public GameObject[] panels;
    public Transform finalPanelTransform; // Reference to the final panel's transform
    private int currentPanelIndex = 0;

    private int correctCount = 0;
    private int incorrectCount = 0;

    public Transform progressBar;
    public TextMeshPro messageText; // Reference to the message text

    void Start()
    {
        ShowPanel(currentPanelIndex);
    }

    public void ShowPanel(int index)
    {
        if (index >= 0 && index < panels.Length)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].SetActive(i == index);
            }
            currentPanelIndex = index;
            UpdateProgress();
        }
    }

    public void ShowNextCorrectPanel()
    {
        correctCount++;
        ShowNextPanel();
    }

    public void ShowNextIncorrectPanel()
    {
        incorrectCount++;
        ShowNextPanel();
    }

    public void ShowNextPanel()
    {
        if (currentPanelIndex + 1 < panels.Length)
        {
            int nextIndex = (currentPanelIndex + 1) % panels.Length;
            ShowPanel(nextIndex);
        }
        else
        {
            // All panels have been shown, display final correct answers
            messageText.text = "Final Correct Answers: " + correctCount;

            // Deactivate the final panel
            panels[currentPanelIndex].SetActive(false);

            // Move the message text to the location of the final panel
            messageText.transform.position = finalPanelTransform.position;
        }
    }

    private void UpdateProgress()
    {
        float progress = (currentPanelIndex + 1) / (float)panels.Length;
        progressBar.localScale = new Vector3(progress, progressBar.localScale.y, progressBar.localScale.z);
        messageText.text = "Panel " + (currentPanelIndex + 1) + " of " + panels.Length;
    }
}

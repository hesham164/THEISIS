using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellingGame : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPlate
    {
        public Transform parent;
        public List<Button> correctAnswers;
        public List<Button> incorrectAnswers;
    }

    public List<ButtonPlate> buttonPlates;

    private void Start()
    {
        foreach (var plate in buttonPlates)
        {
            CreateButtonPlate(plate.parent, plate.correctAnswers, plate.incorrectAnswers);
        }
    }

    private void CreateButtonPlate(Transform parent, List<Button> correctAnswers, List<Button> incorrectAnswers)
    {
        List<Button> buttons = new List<Button>();
        buttons.AddRange(correctAnswers);
        buttons.AddRange(incorrectAnswers);
        buttons.Shuffle();

        for (int i = 0; i < parent.childCount; i++)
        {
            Button button = parent.GetChild(i).GetComponent<Button>();
            Button newButton = buttons[i];
            newButton.transform.SetParent(button.transform.parent, false);
            newButton.gameObject.SetActive(true);
            newButton.onClick.AddListener(() =>
            {
                if (correctAnswers.Contains(newButton))
                {
                    OnCorrectAnswer(newButton);
                }
                else
                {
                    OnIncorrectAnswer(newButton);
                }
            });
        }
    }

    private void OnCorrectAnswer(Button button)
    {
        button.image.color = Color.green; // Change color of the button to green
        Debug.Log("Correct answer!");
        // Add your action for correct answer here
    }

    private void OnIncorrectAnswer(Button button)
    {
        button.image.color = Color.red; // Change color of the button to red
        Debug.Log("Incorrect answer!");
        // Add your action for incorrect answer here
    }
}

// Extension method to shuffle a list
public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

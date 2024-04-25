using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows toggling between Tutorial objects using buttons
public class Tutorial_ToggleBetweenTs : MonoBehaviour
{
    public GameObject button1; // Reference to GameObject for Tutorial toggle menu button 1
    public GameObject button2; // Reference to GameObject for Tutorial toggle menu button 2
    public GameObject button3; // Reference to GameObject for Tutorial toggle menu button 3

    public GameObject object1; // Reference to the first Tutorial object
    public GameObject object2; // Reference to the second Tutorial object
    public GameObject object3; // Reference to the third Tutorial object

    // Start is called before the first frame update
    void Start()
    {
        if (object1 != null)
            object1.SetActive(false);

        if (object2 != null)
            object2.SetActive(false);

        if (object3 != null)
            object3.SetActive(false);
    }

    // Activate object1 and deactivate others when button1 is clicked
    public void OnButton1Clicked()
    {
        object1.SetActive(true);
        object2.SetActive(false);
        object3.SetActive(false);
    }

    // Activate object2 and deactivate others when button2 is clicked
    public void OnButton2Clicked()
    {
        object1.SetActive(false);
        object2.SetActive(true);
        object3.SetActive(false);
    }

    // Activate object3 and deactivate others when button3 is clicked
    public void OnButton3Clicked()
    {
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(true);
    }
}

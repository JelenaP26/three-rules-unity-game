using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    private bool task1Completed = false;
    private bool task2Completed = false;

    public Text textMessage;

    public Button task1Button;
    public Button task2Button;
    public Button task3Button;


    private void Start()
    {
        PlayerPrefs.DeleteKey("Task1Completed");
        PlayerPrefs.DeleteKey("Task2Completed");

        task1Completed = PlayerPrefs.GetInt("Task1Completed", 0) == 1;
        task2Completed = PlayerPrefs.GetInt("Task2Completed", 0) == 1;

        //Debug.Log("Task1Completed je: " + task1Completed);
        //Debug.Log("Task2Completed je: " + task2Completed);

        task1Button.onClick.AddListener(taskOne);
        task2Button.onClick.AddListener(taskTwo);
        task3Button.onClick.AddListener(taskThree);
    }

    public void taskOne()
    {
        SceneManager.LoadScene("Task1Scene");
        // task1Completed = true;
    }

    public void taskTwo()
    {
        if (!task1Completed)
        {
            ShowMessage("No! You have to finish Task 1!");
            Debug.Log("Task 1 not completed yet!");
            return;
        }
        SceneManager.LoadScene("Task2Scene");
        // task2Completed = true;
    }

    public void taskThree()
    {
        if (!task2Completed)
        {
            ShowMessage("No! You have to finish Task 2!");
            Debug.Log("Task 1 not completed yet!");
            return;
        }
        SceneManager.LoadScene("SampleScene");
    }

    void ShowMessage(string text)
    {
        if (textMessage != null)
        {
            textMessage.text = text;
            CancelInvoke(nameof(ClearMessage));
            Invoke(nameof(ClearMessage), 2f); // nestaje za 2 sekunde
        }
    }

    void ClearMessage()
    {
        textMessage.text = "";
    }

}

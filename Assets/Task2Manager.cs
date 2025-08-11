using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task2Manager : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    public Text textMessage;

    // Start is called before the first frame update
    void Start()
    {
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    void OnYesClicked()
    {
        PlayerPrefs.SetInt("Task2Completed", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("TaskScene");
    }

    void OnNoClicked()
    {
        ShowMessage("Umm... you mean Yes, don't you?");
    }

    void ShowMessage(string text)
    {
        if (textMessage != null)
        {
            textMessage.text = text;
            CancelInvoke(nameof(ClearMessage));
            Invoke(nameof(ClearMessage), 3f);
        }
    }

    void ClearMessage()
    {
        textMessage.text = "";
    }
}

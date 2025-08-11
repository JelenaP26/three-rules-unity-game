using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task1Manager : MonoBehaviour
{
    public Button[] plates;
    public Button continueButton;

    private int correctPlateIndex = 1;
    private int selectedPlate = -1;

    public Text textMessage;


    // Start is called before the first frame update
    void Start()
    {
        continueButton.interactable = false;

        for (int i = 0; i < plates.Length; i++)
        {
            int index = i;
            plates[i].onClick.AddListener(() => OnPlateSelected(index));
        }

        continueButton.onClick.AddListener(OnContinueClicked);
    }

    void OnPlateSelected(int index)
    {
        selectedPlate = index;

        if (selectedPlate == correctPlateIndex)
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }


    void OnContinueClicked()
    {
        if (selectedPlate == correctPlateIndex)
        {
            PlayerPrefs.SetInt("Task1Completed", 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene("TaskScene");
        }
    }

    public void OnPlate1Clicked()
    {
        ShowMessage("Umm... okay...");
    }

    public void OnPlate2Clicked()
    {
        ShowMessage("Ah, the classic, yes. He is so basic.");
    }

    public void OnPlate3Clicked()
    {
        ShowMessage("Wish he had some flavor... but nope.");
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

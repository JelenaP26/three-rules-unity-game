using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public AudioSource scoreSound;

    public GameObject gameOverScreen;

    public Text highScoreText;
    private int highScore;
    public AudioSource highScoreSound;

    // shake camera
    public Camera mainCamera;

    private bool isShaking = false;
    private float shakeDuration = 0.5f;
    private float shakeMagnitude = 0.3f;
    private float shakeElapsed = 0f;
    private Vector3 originalCamPos;

    private void Start()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (isShaking)
        {
            if (shakeElapsed < shakeDuration)
            {
                Vector3 randomPoint = originalCamPos + Random.insideUnitSphere * shakeMagnitude;
                randomPoint.z = originalCamPos.z;
                mainCamera.transform.position = randomPoint;

                shakeElapsed += Time.deltaTime;
            }
            else
            {
                isShaking = false;
                mainCamera.transform.position = originalCamPos;
            }
        }
    }

    public void StartShake()
    {
        if (!isShaking)
        {
            originalCamPos = mainCamera.transform.position;
            shakeElapsed = 0f;
            isShaking = true;
        }
    }

    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        scoreSound.Play();
    }

    public void restartGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("SampleScene");
    }

    public void menu()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    public void gameOver()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            highScoreSound.Play();
            StartShake();
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        
        gameOverScreen.SetActive(true);
    }

}

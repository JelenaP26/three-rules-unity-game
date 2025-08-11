using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float initialMoveSpeed = 8f;
    public float moveSpeed;
    public float accelerationInterval = 5f;
    public float accelerationAmount = 1f;
    public float maxSpeed = 20f;

    private float timer = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= accelerationInterval)
        {
            moveSpeed += accelerationAmount;
            if (moveSpeed > maxSpeed)
                moveSpeed = maxSpeed;

            timer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ResetGame()
    {
        moveSpeed = initialMoveSpeed;
        timer = 0f;
    }

}

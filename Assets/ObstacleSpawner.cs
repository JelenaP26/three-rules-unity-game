using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnRate = 2;
    public float spawnX = 37;
    public float heightOffset = 5;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnObstacle();
            timer = 0;
        }
        
    }

    void spawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle = obstacles[index];

        float obstacleY = obstacle.transform.position.y;
        float lowestPoint = obstacleY - heightOffset;
        float highestPoint = obstacleY + heightOffset;

        float randomY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);
        Instantiate(obstacle, spawnPosition, transform.rotation);

        // Debug.Log("Spawn X: " + spawnX + " | Spawn Y: " + Random.Range(lowestPoint, highestPoint));
    }
}

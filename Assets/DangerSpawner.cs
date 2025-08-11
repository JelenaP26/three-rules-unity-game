using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSpawner : MonoBehaviour
{
    public GameObject danger;
    public float spawnRate = 0.3f;
    private float timer = 0f;

    private int obstacleLayer;
    public float checkRadius = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleLayer = LayerMask.GetMask("Obstacle");
        // spawnDanger();
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
            spawnDanger();
            timer = 0;
        }
    }

    void spawnDanger()
    {
        Vector3 spawnPos = transform.position;
        Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPos, checkRadius, obstacleLayer);

        //Debug.Log("Spawn pozicija: " + spawnPos + ", Kolizije: " + hits.Length);

        if (hits.Length == 0)
        {
            Instantiate(danger, spawnPos, transform.rotation);
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, checkRadius);
    //}

}

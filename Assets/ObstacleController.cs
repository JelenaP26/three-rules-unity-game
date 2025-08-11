using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // public float moveSpeed = 8;
    private float deadZone = -35;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        float currentSpeed = GameManager.Instance != null ? GameManager.Instance.moveSpeed : 8f;
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}


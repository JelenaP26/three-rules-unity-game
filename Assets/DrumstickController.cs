using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickController : MonoBehaviour
{

    public LogicManager logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            logic.addScore();
            Destroy(gameObject);
        }
    }
}

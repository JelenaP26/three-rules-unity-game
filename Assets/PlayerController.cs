using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpSpeed = 35;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;

    public Sprite idleSprite;
    public Sprite jumpSprite;

    private Collider2D myCollider;
    private SpriteRenderer spriteRenderer;

    private int jumpCnt = 0;
    private int maxJumpCnt = 2;
    private bool wasGrounded = false;

    public LogicManager logic;
    private bool isALive = true;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = myCollider.IsTouchingLayers(groundLayer) || myCollider.IsTouchingLayers(obstacleLayer);

        if (isGrounded && !wasGrounded)
        {
            jumpCnt = 0;
        }

        wasGrounded = isGrounded;

        if (isGrounded)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else
        {
            spriteRenderer.sprite = jumpSprite;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < maxJumpCnt && isALive)
        {
            myRigidBody.velocity = Vector2.up * jumpSpeed;
            jumpCnt++;
            //Debug.Log("Jump Count: " + jumpCnt + " | Is Grounded: " + isGrounded);
        }

        if (transform.position.x < -23)
        {
            logic.gameOver();
            isALive = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // proveri da li treba onTrigger ili ovako i da li na danger treba da bude cekiran trigger
        // proveri da li treba onTrigger ili ovako i da li na danger treba da bude cekiran trigger
        if (collision.gameObject.layer == 8)
        {
            logic.gameOver();
            isALive = false;
        }
    }
}

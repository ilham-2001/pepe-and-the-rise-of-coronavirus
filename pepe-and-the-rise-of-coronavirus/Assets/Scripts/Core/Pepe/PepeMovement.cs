using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeMovement : MonoBehaviour
{
    // Player Component
    private Rigidbody2D body;
    private Animator anim;
    private PlayerHealth plyHealth;
    [Header("Players Movement Parameter")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;
    [SerializeField] private float gravity;

    private float moveX;
    private bool jumping;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        plyHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {

        moveX = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(moveX * movementSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            Jump();
        }

        if (moveX > 0)
        {
            transform.localScale = new Vector3(scaleX, scaleY, transform.position.z);
        }

        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, transform.position.z);
        }

        setAnimation();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle")
        {
            plyHealth.TakeDamage(1);
        }
    }

    private void setAnimation()
    {
        anim.SetBool("isWalk", moveX != 0);
    }

    private void Jump()
    {
        body.gravityScale = gravity;
        body.velocity = new Vector2(body.velocity.x, movementSpeed);
        jumping = true;
        anim.SetTrigger("jumping");

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("Hit");
        if (col.gameObject.tag == "Ground")
        {
            body.gravityScale = 1;
            jumping = false;
        }
    }

    public bool CanAttack()
    {
        return moveX == 0 && !jumping;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private int speed;
    private Rigidbody2D body;
    private Collider2D playerCollider;
    private CollisionManager collisionManager;
    [SerializeField]private bool isJumping;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        collisionManager = GetComponent<CollisionManager>();

        speed = 10;
    }

    // Update is called once per frame
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(inputX * speed, body.velocity.y);


        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionManager.addCollision(collision);

        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "wall")
        {
            body.rotation = (float)90;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionManager.removeCollision(collision);   
    }
}

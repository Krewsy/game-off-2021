using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Collider2D playerCollider;
    private CollisionManager collisionManager;
    [SerializeField] private int speed;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isClimbing;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        collisionManager = GetComponent<CollisionManager>();

        // might adjust this later
        speed = 7;
    }

    // Update is called once per frame
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        float yx = inputX * speed;
        float yv = body.velocity.y;

        if (canClimb())
        {
            if (inputY != 0)
            {
                body.rotation = (float)90;
                yv = inputY * speed;
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }
        body.velocity = new Vector2(yx, yv);

        body.gravityScale = (float)((isClimbing) ? 0 : 1);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
            isClimbing = false;
        }

        if (!isClimbing)
        {
            //need to play with positioning a little bit to make sure the player sticks to the wall
            //as it stands if we reset rotation here then it will always push us off of the wall
            //body.rotation = 0;
        }
    }

    private bool canClimb()
    {
        return collisionManager.getCollidersWithTag("wall").Count > 0;
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionManager.addCollision(collision);
        
        //allow jump if we collide with a solid surface
        string[] validTags = { "ground", "wall", "ceiling" };

        if (validTags.Contains(collision.gameObject.tag))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionManager.removeCollision(collision);   
    }
}

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

    //input values
    private float inputX;
    private float inputY;

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
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");


        float yx = inputX * speed;
        float yv = body.velocity.y;

        

        if (canClimb())
        {
            if (inputY != 0)
            {
                //body.rotation = (float)90;
                yv = inputY * speed;
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }
        body.velocity = new Vector2(yx, yv);

        body.gravityScale = (float)(isClimbing ? 0 : 1);

        // without this, when you let go of a ceiling or wall you will get a free jump
        // that isn't technically a bad thing but unless we nerf jumps pretty hard
        // it is going to make it trivial to clear some pretty huge gaps
        if (!isJumping && collisionManager.GetColliders().Count == 0)
        {
            isJumping = true;
        }

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
        List<Collider2D> tempCollisions = new List<Collider2D>();

        // get all climbable colliders
        tempCollisions.AddRange(collisionManager.GetCollidersWithTag("wall"));
        tempCollisions.AddRange(collisionManager.GetCollidersWithTag("ceiling"));

        // the old way would let us "climb" something we were standing on causing a bouncy effect... this should fix that
        bool canClimb = tempCollisions.Where(j => j.bounds.extents.y + j.bounds.center.y > playerCollider.bounds.center.y - playerCollider.bounds.extents.y).Any();

        return canClimb;
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionManager.AddCollision(collision);
        
        //allow jump if we collide with a solid surface
        string[] validTags = { "ground", "wall", "ceiling" };

        if (validTags.Contains(collision.gameObject.tag))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionManager.RemoveCollision(collision);   
    }
}

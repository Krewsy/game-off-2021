using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all collisions for the entity.
/// </summary>
public class CollisionManager : MonoBehaviour
{
    private Dictionary<Collider2D, Direction> collisions = new Dictionary<Collider2D, Direction>();
    [SerializeField] private List<string> debugCollisions = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
    }

    public void addCollision(Collision2D collision)
    {
        collisions.Add(collision.collider, getCollisionDirection(collision));
        debugCollisions.Add(GetComponent<Collider2D>().gameObject.tag + ": " + getCollisionDirection(collision));
        
    }

    public void removeCollision(Collision2D collision)
    {
        collisions.Remove(collision.collider);
    }

    private Direction getCollisionDirection(Collision2D collision)
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, collision.gameObject.transform.position,);

        if (hit.collider != null)
        {
            Vector2 collisionPosition = hit.collider.gameObject.transform.position;
            Debug.Log($"Player: {transform.position.x}, {transform.position.y}");
            Debug.Log($"Collider: {collisionPosition.x}, {collisionPosition.y}");
            float theta = Mathf.Atan2((transform.position.x - collisionPosition.x), (transform.position.y - collisionPosition.y));
            Debug.Log("Angle: " + theta.ToString());

        }



        //foreach (ContactPoint2D c in collision.contacts)
        //{
        //    if (transform.position.x < c.point.x)
        //    {
        //        return Direction.Right;
        //    }
        //    else
        //    {
        //        return Direction.Left;
        //    }
        //}

        return Direction.Left;


    }

    // Update is called once per frame
    // We probably won't use this
    void Update()
    {
        
    }
}

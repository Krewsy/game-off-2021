using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handles all collisions for the entity.
/// </summary>
public class CollisionManager : MonoBehaviour
{
    [SerializeField] private List<Collider2D> collisions = new List<Collider2D>();

    private Collider2D playerCollider;
    void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    public void AddCollision(Collision2D collision)
    {
        collisions.Add(collision.collider);

    }

    public void AddCollider(Collider2D collider)
    {
        collisions.Add(collider);
    }

    public void RemoveCollider(Collider2D collider)
    {
        collisions.Remove(collider);
    }

    public void RemoveCollision(Collision2D collision)
    {
        collisions.Remove(collision.collider);
    }

    public List<Collider2D> GetCollidersWithTag(string tag)
    {
        return collisions.Where(i => i.gameObject.tag == tag).ToList();
    }

    public List<Collider2D> GetCollidersOfType<T>()
    {
        return collisions.Where(i => i.gameObject is T).ToList();
    }

    public List<Collider2D> GetColliders()
    {
        return collisions;
    }

    // i will figure this out later if we need it but i think i can just work around it

    //private Direction getCollisionDirection(Collision2D collision)
    //{

    //    // i wanted to do this differently but i got tired of messing with it so this will work for now
    //    Bounds c_Bounds = collision.collider.bounds;
    //    Vector2 collisionTopRight = new Vector2(c_Bounds.center.x + c_Bounds.extents.x, c_Bounds.center.y + c_Bounds.extents.y);
    //    Vector2 collisionTopLeft = new Vector2(c_Bounds.center.x - c_Bounds.extents.x, c_Bounds.center.y + c_Bounds.extents.y);
    //    Vector2 collisionBottomRight = new Vector2(c_Bounds.center.x + c_Bounds.extents.x, c_Bounds.center.y - c_Bounds.extents.y);
    //    Vector2 collisionBottomLeft = new Vector2(c_Bounds.center.x - c_Bounds.extents.x, c_Bounds.center.y - c_Bounds.extents.y);

    //    Bounds p_Bounds = playerCollider.bounds;
    //    Vector2 playerTopRight = new Vector2(p_Bounds.center.x + p_Bounds.extents.x, p_Bounds.center.y + p_Bounds.extents.y);
    //    Vector2 playerTopLeft = new Vector2(p_Bounds.center.x - p_Bounds.extents.x, p_Bounds.center.y + p_Bounds.extents.y);
    //    Vector2 playerBottomRight = new Vector2(p_Bounds.center.x + p_Bounds.extents.x, p_Bounds.center.y - p_Bounds.extents.y);
    //    Vector2 playerBottomLeft = new Vector2(p_Bounds.center.x - p_Bounds.extents.x, p_Bounds.center.y - p_Bounds.extents.y);

    //    if (c_Bounds.center.x > p_Bounds.center.x)
    //    {
    //        if (collisionBottomLeft.x > playerBottomRight.x)
    //        {
    //            return Direction.Right;
    //        }
    //        else
    //        {
    //            if (collisionTopLeft.y < playerBottomLeft.y)
    //            {
    //                return Direction.Down;
    //            }
    //            else
    //            {
    //                return Direction.Up;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (collisionBottomRight.x < playerBottomLeft.x)
    //        {
    //            return Direction.Left;
    //        }
    //        else
    //        {
    //            if (collisionTopLeft.y < playerBottomLeft.y)
    //            {
    //                return Direction.Down;
    //            }
    //            else
    //            {
    //                return Direction.Up;
    //            }
    //        }
    //    }
    //}

}

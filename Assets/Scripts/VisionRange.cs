using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRange : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField]bool chasePlayer;
    [SerializeField]Rigidbody2D targetBody;
    int speed = 7;
    [SerializeField] int direction;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        chasePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // make sure we have something to chase and that we SHOULD be chasing it
        if (targetBody != null && chasePlayer)
        {
            Vector2 targetPos = targetBody.position;

            // determine whether to go left or right
            direction = (targetBody.position.x < body.position.x) ? -1 : 1;

            body.velocity = new Vector2(speed * direction, body.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // don't want to chase walls and shit
        if (collision.gameObject.tag == "player")
        {
            chasePlayer = true;
            targetBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Chasing player!");
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class AIMovement : MonoBehaviour
{
    [SerializeField]private bool isBusy;
    private Rigidbody2D body;
    [SerializeField]public AIBehavior currentActivity;
    private float lastActivityTime;

    private void Awake()
    {
        isBusy = false;
        body = GetComponent<Rigidbody2D>();
        lastActivityTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - lastActivityTime >= 3)
        {
            isBusy = false;
        }

        if (!isBusy && currentActivity != AIBehavior.Sleeping)
        {
            DetermineActivity();
        }
    }

    private void DetermineActivity()
    {
        // temp
        currentActivity = (AIBehavior)Random.Range(0, 3);

        switch (currentActivity)
        {
            case AIBehavior.WalkingRight:
                body.velocity = new Vector2(5, body.velocity.y);
                break;

            case AIBehavior.WalkingLeft:
                body.velocity = new Vector2(-5, body.velocity.y);
                break;

            default:
                break;
        }
        isBusy = true;
        lastActivityTime = Time.realtimeSinceStartup;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollider : MonoBehaviour
{
    new Collider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionManager targCollMan;
        if ((targCollMan = collision.gameObject.GetComponent<CollisionManager>()) != null)
        {
            targCollMan.AddCollider(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CollisionManager targCollMan;
        if ((targCollMan = collision.gameObject.GetComponent<CollisionManager>()) != null)
        {
            targCollMan.RemoveCollider(collider);
        }
    }
}

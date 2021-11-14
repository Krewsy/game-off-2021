using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismountable : MonoBehaviour
{
    [SerializeField] private float inputY;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        inputY = Input.GetAxis("Vertical");

        if (collision.gameObject.tag == "player" && inputY < 0)
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}

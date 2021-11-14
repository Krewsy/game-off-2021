using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public Transform grabDetect;
    public Transform foodHolder;
    public float rayDist;

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Food")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = foodHolder;
                grabCheck.collider.gameObject.transform.position = foodHolder.position;
                
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private AIMovement aim;
    private VisionRange vr;

    // Start is called before the first frame update
    void Awake()
    {
        aim = GetComponent<AIMovement>();
        vr = GetComponent<VisionRange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

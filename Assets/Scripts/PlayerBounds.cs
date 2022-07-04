using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public Vector3 circleCenter;
    public Transform player;
    public float radius = 4.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, circleCenter);

        if (dist > radius)
        {
            Vector3 fromOriginToObject = player.position - circleCenter;
            fromOriginToObject *= radius / dist;
            player.position = circleCenter + fromOriginToObject;
            transform.position = player.position;
        }
    }
}

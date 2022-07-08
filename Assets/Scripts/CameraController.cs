using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float newXposition = Player.transform.position.x - offset.x;
        float newYposition = Player.transform.position.y - offset.y;

        transform.position = new Vector3 (newXposition, newYposition, transform.position.z);
    }
}

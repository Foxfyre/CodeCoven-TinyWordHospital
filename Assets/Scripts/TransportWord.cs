using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportWord : MonoBehaviour
{

    bool canPickup;
    string label;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPickup == true && label == "word")
        {
            print("YOU CAN PICK UP THE WORD!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canPickup = true;
        label = collision.gameObject.tag;
        print("Your are in the space");
        print(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPickup = false;
        label = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportWord : MonoBehaviour
{
    public GameObject wordObject;
    bool canPickup;
    string label;
    string collisionName;
    public Text txt;
    static bool hasWord;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPickup == true && label == "word" && hasWord == false)
        {
            //print("YOU CAN PICK UP THE WORD!");
            //gets the game object information from the object collided into
            GameObject gO = GameObject.Find(collisionName);
            txt = gO.GetComponentInChildren<Text>();
            //print(txt.text);
            //txt.text = wordObject.display;

            //gets the game object of the ambulance
            GameObject gA = GameObject.Find("Ambulance");
            GameObject gW = GameObject.Find("WordHolder");
            Text gAtext = gA.GetComponentInChildren<Text>();
            gAtext.text = txt.text;
            gW.GetComponent<SpriteRenderer>().enabled = true;
            gAtext.enabled = true;

            gO.GetComponent<SpriteRenderer>().enabled = false;
            gO.GetComponentInChildren<Text>().enabled = false;
            hasWord = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canPickup = true;
        label = collision.gameObject.tag;
        //print("Your are in the space");
        //print(collision.gameObject);
        collisionName = collision.gameObject.name;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPickup = false;
        label = "";
    }

    public static void ResetTransport()
    {
        hasWord = false;
    }
}

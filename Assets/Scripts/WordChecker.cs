using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordChecker : MonoBehaviour
{

    bool canDrop;
    bool hasWord;
    string collisionName;
    GameObject Ambulance;
    Text theWord;
    string brokenWord;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDrop == true && hasWord == true) 
        {
            //print("YOU CAN DROP THE WORD");

            GameObject gurney = GameObject.Find("WordGurney");
            GameObject gW = GameObject.Find("WordHolder");
            Text gurneyText = gurney.GetComponentInChildren<Text>();
            gurneyText.text = brokenWord;
            gurneyText.enabled = true;
            gurney.GetComponent<SpriteRenderer>().enabled = true;

            gW.GetComponent<SpriteRenderer>().enabled = false;
            Ambulance.GetComponentInChildren<Text>().enabled = false;

            GameObject mCamera = GameObject.Find("Main Camera");
            mCamera.GetComponent<Camera>().enabled = false;

            GameObject dCamera = GameObject.Find("WordDisplayCamera");
            dCamera.GetComponent<Camera>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("THE GURNEY IS TRIGGERED!");
        canDrop = true;
        collisionName = collision.gameObject.name;
        if (collisionName == "Ambulance")
        {
            Ambulance = collision.gameObject;
        }

        if (Ambulance != null)
        {
            hasWord = Ambulance.GetComponentInChildren<SpriteRenderer>().enabled;
            Text theWord = Ambulance.GetComponentInChildren<Text>();
            brokenWord = theWord.text;
            print(brokenWord);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canDrop = false;
        collisionName = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordChecker : MonoBehaviour
{

    bool canDrop = false;
    public bool hasWord = false;
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
            canDrop = false;
            hasWord = false;
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
            hasWord = Ambulance.GetComponentInChildren<Text>().enabled;
            Text theWord = Ambulance.GetComponentInChildren<Text>();
            brokenWord = theWord.text;
            //print(brokenWord);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canDrop = false;
        collisionName = "";
    }

    //Add function to reset the bools
    public static void ResetPlayer()
    {
        GameObject gurney = GameObject.Find("WordGurney");
        Text gurneyText = gurney.GetComponentInChildren<Text>();
        gurneyText.text = "";
        gurneyText.enabled = false;
        gurney.GetComponent<SpriteRenderer>().enabled = false;

        GameObject mCamera = GameObject.Find("Main Camera");
        mCamera.GetComponent<Camera>().enabled = true;

        GameObject dCamera = GameObject.Find("WordDisplayCamera");
        dCamera.GetComponent<Camera>().enabled = false;

    }
}

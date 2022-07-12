using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{

    private WordImporter.WordList myWordList = new WordImporter.WordList();
    List<string> options;
    string option1;
    string option2;
    string option3;

    public Button FirstSelection, SecondSelection, ThirdSelection;


    void Start()
    {
        FirstSelection.onClick.AddListener(() => CheckWord(option2));
        SecondSelection.onClick.AddListener(() => CheckWord(option2));
        ThirdSelection.onClick.AddListener(() => CheckWord(option3));
        myWordList = FindObjectOfType<WordImporter>().SendWords();
        print(myWordList.words.Length);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gurney = GameObject.Find("WordGurney");
        Text gurneyText = gurney.GetComponentInChildren<Text>();
        string gurneyString = gurneyText.text;

        if (gurneyText.enabled == true)
        {

            //print(gurneyString);
            for (int i = 0; i < myWordList.words.Length; i++)
            {
                //Debug.Log("WORD DISPLAY FIRING");
                //print(myWordList.words[i].name == gurneyString);
                options = myWordList.words[i].options;
                if (options.Contains(gurneyString))
                {
                    option1 = options[0];
                    option2 = options[1];
                    option3 = options[2];
                    //print(option1);
                }

            }

            GameObject wordDisplay1 = GameObject.Find("WordChoice1");
            Text WordDisplay1Text = wordDisplay1.GetComponentInChildren<Text>();
            WordDisplay1Text.text = option1;
            WordDisplay1Text.enabled = true;

            GameObject wordDisplay2 = GameObject.Find("WordChoice2");
            Text WordDisplay2Text = wordDisplay2.GetComponentInChildren<Text>();
            WordDisplay2Text.text = option2;
            WordDisplay2Text.enabled = true;

            GameObject wordDisplay3 = GameObject.Find("WordChoice3");
            Text WordDisplay3Text = wordDisplay3.GetComponentInChildren<Text>();
            WordDisplay3Text.text = option3;
            WordDisplay3Text.enabled = true;

            

        }
    }

    void CheckWord(string option)
    {
        print("Button Clicked!");
        myWordList = FindObjectOfType<WordImporter>().SendWords();

        GameObject gurney = GameObject.Find("WordGurney");
        Text gurneyText = gurney.GetComponentInChildren<Text>();
        string gurneyString = gurneyText.text;

        string correctAnswer = "";

        for (int i = 0; i < myWordList.words.Length; i++)
        {
            if (options.Contains(gurneyString))
            {
                correctAnswer = myWordList.words[i].name;
            }
        }

        if (option == correctAnswer)
        {
            Debug.Log("YES!");
        }
        else
        {
            Debug.Log("No!");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{

    private WordImporter.WordList myWordList = new WordImporter.WordList();
    List<string> options;
    List<string> optionsList = new List<string>();
    string option1;
    string option2;
    string option3;

    public Button FirstSelection, SecondSelection, ThirdSelection;


    void Start()
    {
        FirstSelection.onClick.AddListener(() => CheckWord(option1));
        SecondSelection.onClick.AddListener(() => CheckWord(option2));
        ThirdSelection.onClick.AddListener(() => CheckWord(option3));
        myWordList = FindObjectOfType<WordImporter>().SendWords();
        //print(myWordList.words.Length);
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
                    optionsList.Add(option1);
                    optionsList.Add(option2);
                    optionsList.Add(option3);
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
        myWordList = FindObjectOfType<WordImporter>().SendWords();

        GameObject gurney = GameObject.Find("WordGurney");
        Text gurneyText = gurney.GetComponentInChildren<Text>();
        string gurneyString = gurneyText.text;
        string correctAnswer = "";

        //Get selected word
        //Find word options that contain the gurney word
        //Compare selected word to Name of word object. 
        for (int b = 0; b < myWordList.words.Length; b++)
        {
            if (myWordList.words[b].options.Contains(gurneyString))
            {
                correctAnswer = myWordList.words[b].name;
            }
        }

        print("The correct answer is " + correctAnswer);
        print("You selected " +option);

        if (option == correctAnswer)
        {
            Debug.Log("YES!");
            ScoreManager.UpdateScoreDisplay();
        }
        else
        {
            Debug.Log("No!");
        }
    }

    public static void DisplayReset()
    {
        GameObject wordDisplay1 = GameObject.Find("WordChoice1");
        Text WordDisplay1Text = wordDisplay1.GetComponentInChildren<Text>();
        WordDisplay1Text.text = "";
        WordDisplay1Text.enabled = false;

        GameObject wordDisplay2 = GameObject.Find("WordChoice2");
        Text WordDisplay2Text = wordDisplay2.GetComponentInChildren<Text>();
        WordDisplay2Text.text = "";
        WordDisplay2Text.enabled = false;

        GameObject wordDisplay3 = GameObject.Find("WordChoice3");
        Text WordDisplay3Text = wordDisplay3.GetComponentInChildren<Text>();
        WordDisplay3Text.text = "";
        WordDisplay3Text.enabled = false;

        
    }


}

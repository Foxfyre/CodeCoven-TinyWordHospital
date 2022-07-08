using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGenerator : MonoBehaviour
{
    public TextAsset textJSON;
    public Text txt;
    [System.Serializable]
    public class Word
    {
        public string name;
        public string display;
        public string[] options;
    }

    [System.Serializable]
    public class WordList
    {
        public Word[] words;
    }

    public WordList myWordList = new WordList();
    public ArrayList selectedNumbers = new ArrayList();
    public GameObject[] blocksArr;
    public List<int> selectedBlocks = new List<int>();
    public int wordCount = 3;
    int rng;
    int wordRng;

    // Start is called before the first frame update
    void Start()
    {
        myWordList = JsonUtility.FromJson<WordList>(textJSON.text);

        // on start, choose x amount of blocks from the block array & "replace" them with word object. 
        int randSelect = blocksArr.Length;
        for (int i = 0; i < wordCount; i++)
        {
            rng = Random.Range(0, randSelect);
            if (selectedBlocks.Contains(rng))
            {
                i--;
            }
            else
            {
                selectedBlocks.Add(rng);

            }
        }

        //print(myWordList.words[1].name);

        /*foreach (var item in myWordList.words)
        {
            print(item.name);
            // Parse items into data struct
        }*/

        for (int i = 0; i < selectedBlocks.Count; i++)
        {
            wordRng = Random.Range(0, myWordList.words.Length);
            print(wordRng);
            print(selectedNumbers.Contains(wordRng));
            //selectedNumbers.Add(wordRng);
            object wordObject;

            if (selectedNumbers.Contains(wordRng))
            {
                while (selectedNumbers.Contains(wordRng))
                {
                    wordRng = Random.Range(0, myWordList.words.Length);
                }
                selectedNumbers.Add(wordRng);
                wordObject = myWordList.words[wordRng];
                print(wordRng);
            }
            else
            {
                selectedNumbers.Add(wordRng);
                wordObject = myWordList.words[wordRng];
            }


            //get a word from myWordList
            GameObject GO = blocksArr[selectedBlocks[i]];
            GameObject.Find("Text");
            txt = GO.GetComponentInChildren<Text>();
            txt.text = myWordList.words[wordRng].display;
            GO.tag = "word";
            GO.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public TextAsset textJSON;

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

    public GameObject[] blocksArr;
    public List<int> selectedBlocks = new List<int>();
    public int wordCount = 3;
    int rng;

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
                selectedBlocks.Add(Random.Range(0, randSelect));
                Debug.Log(selectedBlocks[i]);
            }
        }
        for (int i = 0; i < selectedBlocks.Count; i++)
        {
            GameObject GO = blocksArr[selectedBlocks[i]];
            GO.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

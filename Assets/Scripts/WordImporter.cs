using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordImporter : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]
    public class Word
    {
        public string name;
        public string display;
        public List<string> options;
    }

    [System.Serializable]
    public class WordList
    {
        public Word[] words;
    }

    public WordList myWordList = new WordList();

    // Start is called before the first frame update

    void Start()
    {
        myWordList = JsonUtility.FromJson<WordList>(textJSON.text);
    }

    public WordList SendWords()
    {
        return myWordList;
    }
}

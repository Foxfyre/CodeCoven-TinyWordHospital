using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public static int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseScore(int score)
    {
        score += score;
        UpdateScoreDisplay();

    }

    public static void UpdateScoreDisplay()
    {
        GameObject emptyHeart1 = GameObject.Find("EmptyHeart1");
        GameObject emptyHeart2 = GameObject.Find("EmptyHeart2");
        GameObject emptyHeart3 = GameObject.Find("EmptyHeart3");
        GameObject fullHeart1 = GameObject.Find("Heart1");
        GameObject fullHeart2 = GameObject.Find("Heart2");
        GameObject fullHeart3 = GameObject.Find("Heart3");
        score++;
        if (score == 1)
        {
            emptyHeart1.GetComponent<Image>().enabled = false;
            fullHeart1.GetComponent<Image>().enabled = true;
        }
        if (score == 2)
        {
            emptyHeart2.GetComponent<Image>().enabled = false;
            fullHeart2.GetComponent<Image>().enabled = true;
        }
        if (score == 3)
        {
            emptyHeart3.GetComponent<Image>().enabled = false;
            fullHeart3.GetComponent<Image>().enabled = true;

        }

        print(score);
        WordChecker.ResetPlayer();
        WordDisplay.DisplayReset();
        TransportWord.ResetTransport();
        

        if (score == 3)
        {
            SceneManager.LoadScene("Win Scene");
            score = 0;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public int[] randomItem = new int[5];
    public int i = 0;
    private int itemRandom;

    public string[] items;

    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject gameWin;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();

        score = Random.Range(1, 5);

        randomItem[i] = Random.Range(0, items.Length);

        scoreText.text = items[randomItem[i]] + " " + score;
    }

    public void ScoreFunction()
    {
        if(i >= 2)
        {
            WonTheGame();
        }
        else
        {
            do
            {
                score = Random.Range(1, 5);
                itemRandom = Random.Range(0, items.Length);
            }
            while (itemRandom == randomItem[i]);

            i++;
            randomItem[i] = itemRandom;
            scoreText.text = items[randomItem[i]] + " " + score;
        }        
    }

    private void WonTheGame()
    {
        scoreText.text = "";
        gameWin.SetActive(true);
    }
}

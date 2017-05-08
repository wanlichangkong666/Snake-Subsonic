using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Scores : MonoBehaviour {
    //public static int highScore=0;
   
    // Use this for initialization
    void Start () {
        GameObject.Find("YourScore").GetComponent<Text>().text = "Your score:" + SnakeMove.scores;
       
        Show(SnakeMove.scores);
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Show(int nowScore)
    {
        int highScore = PlayerPrefs.GetInt("highScores", 0);
        //PlayerPrefs.SetInt("highScores", 0);
        if (SnakeMove.scores > highScore)
            PlayerPrefs.SetInt("highScores", SnakeMove.scores);
         highScore = PlayerPrefs.GetInt("highScores");
        GameObject.Find("TheHighestScore").GetComponent<Text>().text = "Your highest score:" + highScore;
        // Debug.Log(highScore);
    }

}

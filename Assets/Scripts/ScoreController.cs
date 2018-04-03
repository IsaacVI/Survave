using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static bool scoreGrowing;
	public static float score;
	public float multipler;
	Text scoreText;
    private Text bestScoreText;
    public static int bestScore;

	public static void StopGrowing()
	{
		scoreGrowing = false;
	}

    

	// Use this for initialization
	void Start () {
		score = 0;
		scoreGrowing = true;
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
        bestScoreText = GameObject.Find("bestScore").GetComponent<Text>();
	    bestScore = PlayerPrefs.GetInt("BestScore");
	    bestScoreText.text = bestScore.ToString() + "m";
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreGrowing)
			score += Time.deltaTime * multipler;
		scoreText.text = ((int)score).ToString()+"m";

	}
}

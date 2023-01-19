using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;

	void Start()
	{
		scoreText = GetComponent<TMP_Text>();
		scoreText.text = "Score: 0";
	}
	public void increaseScore(int hitScore)
	{
        score += hitScore;
		scoreText.text = "Score: " + score.ToString();
	}
}

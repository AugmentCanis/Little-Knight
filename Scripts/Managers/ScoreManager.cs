using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public static int scoreValue;

	public void AddPoints(int value) {
		scoreValue += value;
		score.text = "Score: " + scoreValue;

		// Set highscore
		if(scoreValue > PlayerPrefs.GetInt("highscore", 0)) {
			PlayerPrefs.SetInt("highscore", ScoreManager.scoreValue);
		}
		// Add money
		int money = PlayerPrefs.GetInt("money", 0) + value;
		PlayerPrefs.SetInt("money", money);
	}
}

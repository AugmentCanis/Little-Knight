using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Text highScoreText;

	void Start() {
		UpdateHighscore();
	}

	public void UpdateHighscore() {
		highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);
	}

	public void Play() {
		ScoreManager.scoreValue = 0; // reset score

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ResetGame() {
		//.DeleteAll(); -> reset everything
		PlayerPrefs.DeleteKey("highscore");
		PlayerPrefs.DeleteKey("money");
		PlayerPrefs.DeleteKey("healthUpgrade");
		PlayerPrefs.DeleteKey("shieldUpgrade");
		PlayerPrefs.Save();
	}

	public void Quit() {
		Application.Quit();
	}
}

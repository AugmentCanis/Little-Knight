using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Text highScoreText;

	void Start() {
		// Reset static variables
		GameOverManager.gameOver = false;
		GameOverManager.hasKey = false;
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
		float sfxVol = PlayerPrefs.GetFloat("sfxVolume", 1);
		float musicVol = PlayerPrefs.GetFloat("musicVolume", 1);
		PlayerPrefs.DeleteAll(); // reset everything
		PlayerPrefs.SetFloat("sfxVolume", sfxVol);
		PlayerPrefs.SetFloat("musicVolume", musicVol);
		PlayerPrefs.Save();
	}

	public void Quit() {
		Application.Quit();
	}
}

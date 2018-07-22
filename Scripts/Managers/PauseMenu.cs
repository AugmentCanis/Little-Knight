using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gamePaused = false;

	void Start () {
		if(gamePaused) {
			Pause();
		} else {
			Resume();
		}
	}
	
	public void Pause() {
		Time.timeScale = 0f;
	}

	public void Resume() {
		Time.timeScale = 1f;
	}

	public void MainMenu() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void Quit() {
		Application.Quit();
	}
}

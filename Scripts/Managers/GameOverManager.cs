using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public static bool gameOver = false, hasKey = false;

	public GameObject player;
	public GameObject gameCanvas, gameOverCanvas;
	public float gameOverTime;

	float endTimer;

	void Start() {
		endTimer = gameOverTime;
	}

	void Update() {
		if(player == null) {
			gameOver = true;
		}

		if(gameOver) {
			gameCanvas.SetActive(false);
			gameOverCanvas.SetActive(true);
			
			gameOverCanvas.GetComponentInChildren<Text>().text = "Score: " + ScoreManager.scoreValue;

			if(endTimer > 0f) {
				endTimer -= Time.deltaTime;
			} else {
				if(Input.GetMouseButton(0)) {
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
				}
			}
		}
	}

	public void QuitGame() {
		gameOver = true;
	}
}

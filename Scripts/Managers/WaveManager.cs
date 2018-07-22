using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public GameObject waveText, player, enemy1, enemy2;
	public Vector2 posX, posY;
	public float pauseTime, spawnIntervalTime;

	Vector2 pos;
	int waveNumber;
	bool spawningWave;

	void Start () {
		spawningWave = true;
		StartCoroutine("SpawnWave");
	}

	void Update() {
		if(!spawningWave && GameObject.FindGameObjectWithTag("Enemy") == null) {
			spawningWave = true;
			StartCoroutine("SpawnWave");
		}
	}
	
	IEnumerator SpawnWave() {
		yield return new WaitForSeconds(pauseTime / 3);
		waveNumber++;
		waveText.GetComponent<Text>().text = "WAVE " + waveNumber;
		waveText.SetActive(true);
		yield return new WaitForSeconds(pauseTime / 3);
		waveText.SetActive(false);
		yield return new WaitForSeconds(pauseTime / 3);
		for(int i = 0; i <= (waveNumber + 1) / 2; ++i) { // wavenumber + 1 ca sa inceapa cu 2 skeletoni in loc de 1
			pos.x = Random.Range(posX.x, posX.y);
			pos.y = Random.Range(posY.x, posY.y);

			if(waveNumber % 2 == 1) {
				Instantiate(enemy1, pos, enemy1.transform.rotation);
			} else {
				Instantiate(enemy2, pos, enemy1.transform.rotation);
			}

			yield return new WaitForSeconds(spawnIntervalTime);
		}
		spawningWave = false;
	}
}

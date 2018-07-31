using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	const int bossWave = 20;  
	
	public static bool pauseGame = false;

	public GameObject waveText, player, enemy1, enemy2, boss1, boss2, key;
	public Vector2 posX, posY;
	public float pauseTime, spawnIntervalTime;

	IEnumerator coroutine;
	Vector2 pos, bossPos;
	public int waveNumber;
	bool spawningWave;

	void Start () {
		spawningWave = true;
		coroutine = SpawnWave();
		StartCoroutine(coroutine);
	}

	void Update() {
		/*if(pauseGame) {
			StopCoroutine(coroutine);
			spawningWave = false;
			return;
		}*/

		if(waveNumber == bossWave) {
			if(boss1 != null) {
				bossPos = boss1.transform.position;
			} else if(boss2 != null) {
				bossPos = boss2.transform.position;
			}
		}

		if(!spawningWave && GameObject.FindGameObjectWithTag("Enemy") == null) {
			if(waveNumber == bossWave && !GameOverManager.hasKey) {
				Instantiate(key, bossPos, key.transform.rotation);
				pauseTime = pauseTime * 1.5f;
			} else if(waveNumber == bossWave) {
				waveNumber++;
			}
			spawningWave = true;
			coroutine = SpawnWave();
			StartCoroutine(coroutine);
		}
	}

	public void UnpauseGame() {
		pauseGame = false;
	}
	
	IEnumerator SpawnWave() {
		yield return new WaitForSeconds(pauseTime / 3);
		waveNumber++;
		waveText.GetComponent<Text>().text = "WAVE " + waveNumber;
		waveText.SetActive(true);
		yield return new WaitForSeconds(pauseTime / 3);
		waveText.SetActive(false);
		yield return new WaitForSeconds(pauseTime / 3);

		if(waveNumber == bossWave) {
			pos.x = Random.Range(posX.x, posX.y);
			pos.y = Random.Range(posY.x, posY.y);
			Instantiate(boss1, pos, boss1.transform.rotation);
			
			pos.x = Random.Range(posX.x, posX.y);
			pos.y = Random.Range(posY.x, posY.y);
			Instantiate(boss2, pos, boss2.transform.rotation);
		} else for(int i = 0; i <= (waveNumber + 1) / 2; ++i) { // wavenumber + 1 ca sa inceapa cu 2 skeletoni in loc de 1
			pos.x = Random.Range(posX.x, posX.y);
			pos.y = Random.Range(posY.x, posY.y);

			if(waveNumber % 2 == 1) {
				Instantiate(enemy1, pos, enemy1.transform.rotation);
			} else {
				Instantiate(enemy2, pos, enemy2.transform.rotation);
			}

			yield return new WaitForSeconds(spawnIntervalTime);
		}
		spawningWave = false;
	}
}

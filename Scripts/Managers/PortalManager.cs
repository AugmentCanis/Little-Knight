﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalManager : MonoBehaviour {

	public Text cantProceed;
	public GameObject confirmEnding, controlUI;

	const float maxVal = 1;
	float val = 0;

	void Update () { 
		if(val > 0)
			val -= Time.deltaTime / 10f;

		cantProceed.color = new Color(maxVal, maxVal, maxVal, val);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player") { 
			if(!GameOverManager.hasKey) {
				val = maxVal;
				cantProceed.color = new Color(val, val, val, val);
			} else {
				WaveManager.pauseGame = true;
				confirmEnding.SetActive(true);
				controlUI.SetActive(false);
			}
		}
	}
}

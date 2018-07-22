using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth, currentHealth, scorePoints;
	public ScoreManager scoreManager;

	void Start () {
		currentHealth = maxHealth;
		scoreManager = GameObject.Find("EventSystem").GetComponent<ScoreManager>();
	}
	
	void Update () {
		if(currentHealth <= 0) {
			scoreManager.AddPoints(scorePoints);
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
	}
}

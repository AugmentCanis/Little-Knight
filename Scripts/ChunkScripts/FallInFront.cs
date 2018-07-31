using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInFront : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "Player") {
			other.gameObject.GetComponent<Animator>().SetBool("isFalling", true);
			
			GameOverManager.gameOver = true;
		}
	}
}

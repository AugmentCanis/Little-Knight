using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBehind : MonoBehaviour {

	public SpriteRenderer player, sleeve, shield;
	public GameObject weapon;

	void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "Player") { 
			other.gameObject.GetComponent<Animator>().SetBool("isFalling", true);

			GameOverManager.gameOver = true;

			// Place the player character and it's components behind the map in the sprite order
			SpriteRenderer spriteRenderer = weapon.GetComponentInChildren<SpriteRenderer>();
			spriteRenderer.sortingOrder = -1;
			player.sortingOrder = -1;
			sleeve.sortingOrder = 0;
			shield.sortingOrder = 0;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float attackDamageMultiplier = 1f;
	public int attackDamage;
	public string enemyTag;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == enemyTag) {
			if(other.GetComponent<Guard>() != null) {
				other.GetComponent<Guard>().TakeDamage((int)(attackDamage * attackDamageMultiplier));
			} else if(other.GetComponent<Health>() != null) {
				other.GetComponent<Health>().TakeDamage((int)(attackDamage * attackDamageMultiplier));
			}
		}
	}
}

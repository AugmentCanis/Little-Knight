using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

	public int maxGuardSize, currentGuardSize;
	public float guardRecoverCooldown; // how long until recover process starts
	public int guardRecoverAmount; // how much a tick of recover builds back the guard
	public float guardRecoverTime; // how long a tick of recover takes

	Health health;
	float guardRecoverCounter;
	bool wasHit;

	void Start () {
		currentGuardSize = maxGuardSize;
		health = gameObject.GetComponent<Health>();
	}
	
	void Update () {
		if(currentGuardSize < 0) {
			health.TakeDamage(Mathf.Abs(currentGuardSize));
			currentGuardSize = 0;
		}

		if(guardRecoverCounter > 0) {
			guardRecoverCounter -= Time.deltaTime;
		} else if(wasHit) {
			wasHit = false;
			StartCoroutine("RecoverGuard");
		}
	}

	public void TakeDamage(int amount) {
		StopCoroutine("RecoverGuard");
		wasHit = true;
		currentGuardSize -= amount;
		guardRecoverCounter = guardRecoverCooldown;
	}

	IEnumerator RecoverGuard() {
		while(currentGuardSize < maxGuardSize) {
			currentGuardSize += guardRecoverAmount;
			
			if(currentGuardSize >= maxGuardSize) { 
				currentGuardSize = maxGuardSize;
				StopCoroutine("RecoverGuard");
			}
			yield return new WaitForSeconds(guardRecoverTime);
		}
	}
}

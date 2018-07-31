using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	const float stopMultiplierTime = 0.2f;

	public static bool isCharging = false;

	public GameObject player, circle, particles;
	public Attack playerAttack;
	public float differenceTime, attackDamageMultiplier;
	public Weapon[] weapons;


	PlayerControl playerControl;
	Image circleImage;

	Animator animator;
	AnimatorClipInfo[] animatorClipInfo;

	float heldDownCounter = 0f, chargeTime, initialAttackMultiplier;
	bool count = false;

	void Start () {
		playerControl = player.GetComponent<PlayerControl>();
		circleImage = circle.GetComponentInChildren<Image>();
		animator = player.GetComponent<Animator>();
		chargeTime = weapons[PlayerPrefs.GetInt("weaponNo", 0)].atkSpd * 3.5f;
	}
	
	void Update () {
		if(count) {
			heldDownCounter += Time.deltaTime;
		}

		if(heldDownCounter > differenceTime) {
			// Begin heavy attack
			animator.SetBool("isAttacking", true);
			animator.speed = 0;
			
			// Start the circle for charging visualization
			if(heldDownCounter <= chargeTime) {
				circleImage.fillAmount = heldDownCounter / chargeTime;
			}
			if(heldDownCounter >= chargeTime) {
				circleImage.color = new Color(1f, 200f/255f, 100f/255f, 200f/255f);
			}
			circle.SetActive(true);
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		count = true;
		isCharging = true;
    }

	public void OnPointerUp(PointerEventData eventData) {
		isCharging = false;

		if(heldDownCounter < differenceTime) {
			playerControl.Attack();
		}
		
		// Continue heavy attack
		if(heldDownCounter >= chargeTime) {
			// Apply the damage modifier
			initialAttackMultiplier = playerAttack.attackDamageMultiplier;
			playerAttack.attackDamageMultiplier = attackDamageMultiplier;
			StartCoroutine(ReduceMultiplier());
		} else {
			particles.SetActive(false);
		}
		
		animator.speed = 1;
		animator.SetBool("isAttacking", false);

		// Remove the visual circle
		circle.SetActive(false);
		circleImage.color = new Color(1f, 1f, 1f, 150f/255f);

        count = false;
		heldDownCounter = 0f;
    }

	IEnumerator ReduceMultiplier() {
		yield return new WaitForSeconds(stopMultiplierTime);
		playerAttack.attackDamageMultiplier = initialAttackMultiplier;
	}
}

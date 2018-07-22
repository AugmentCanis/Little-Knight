using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public GameObject player, circle, particles;
	public Attack playerAttack;
	public float chargeTime, differenceTime, attackDamageMultiplier;


	PlayerControl playerControl;
	Image circleImage;

	Animator animator;
	AnimatorClipInfo[] animatorClipInfo;

	float heldDownCounter = 0f;
	bool count = false;

	void Start () {
		playerControl = player.GetComponent<PlayerControl>();
		circleImage = circle.GetComponentInChildren<Image>();
		animator = player.GetComponent<Animator>();
	}
	
	void Update () {
		if(count) {
			heldDownCounter += Time.deltaTime;
		}

		if(heldDownCounter > differenceTime) {
			// Begin heavy attack
			animator.SetBool("isAttacking", true);
			animator.speed = 0;
			//particles.SetActive(true);
			
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
    }

	public void OnPointerUp(PointerEventData eventData) {
		if(heldDownCounter < differenceTime) {
			playerControl.Attack();
		}
		
		// Continue heavy attack
		if(heldDownCounter >= chargeTime) {
			// Apply the damage modifier
			playerAttack.attackDamageMultiplier = attackDamageMultiplier;
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
}

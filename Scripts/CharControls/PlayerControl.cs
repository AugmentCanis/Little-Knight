using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

	const float stopAnim = .3f, timeToMove = .1f;

	public Slider healthBar, guardBar;
	public float moveSpeed, attackTime;

	Rigidbody2D rgbody;
	Animator anim;
	Health health;
	Guard guard;
	
	Vector2 lastMove = new Vector2(0, -1);
	float attackTimeCounter, attackAnimStopCounter;
	bool isMoving, isAttacking; // For animations
	
	void Start () {
		rgbody = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		health = gameObject.GetComponent<Health>();
		guard = gameObject.GetComponent<Guard>();
	}

	void Update() {
		healthBar.value = (float)health.currentHealth / (float)health.maxHealth;
		guardBar.value = (float)guard.currentGuardSize / (float)guard.maxGuardSize;

		if(attackTimeCounter > 0f) {
			attackTimeCounter -= Time.deltaTime;
		}

		if(attackAnimStopCounter > 0f) {
			attackAnimStopCounter -= Time.deltaTime;
		} else {
			isAttacking = false;
		}
	}
	
	void FixedUpdate () {
		SetAnim();

		if(PlayerAttack.isCharging) {
			rgbody.velocity = Vector2.zero;
		} else if(attackTimeCounter <= timeToMove && !GameOverManager.gameOver) {
			Move();
		}
	}

	void SetAnim() {
		anim.SetBool("isMoving", isMoving);
		anim.SetBool("isAttacking", isAttacking);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

	public void Attack() {
		if(attackTimeCounter <= 0f) {
			rgbody.velocity = Vector2.zero;
			isAttacking = true;
			attackTimeCounter = attackTime;
			attackAnimStopCounter = stopAnim;
		}
	}

	void Move() {
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");

		if(horizontal > 0.4f) {
			horizontal = 1;
		} else if(horizontal < -0.4f) {
			horizontal = -1;
		} else {
			horizontal = 0;
		}

		if(vertical > 0.4f) {
			vertical = 1;
		} else if(vertical < -0.4f) {
			vertical = -1;
		} else {
			vertical = 0;
		}

		Vector2 moveInput = new Vector2(horizontal, vertical).normalized;

		if(moveInput != Vector2.zero) {
			rgbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
			isMoving = true;
			lastMove = moveInput;
		} else {
			rgbody.velocity = Vector2.zero;
			isMoving = false;
		}

		if(!isMoving) {
			rgbody.velocity = Vector2.zero;
		}
	}
}

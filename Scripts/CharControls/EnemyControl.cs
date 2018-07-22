using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	const float stopAnim = .3f;

	public Transform target;
	public float moveSpeed, attackRange, followRange, attackTime;

	Rigidbody2D rgbody;
	Animator anim;
	Vector2 lastMove = new Vector2(0, -1);
	float attackTimeCounter, attackAnimStopCounter;
	bool isMoving, isAttacking; // For Animations

	void Start () {
		if(GameObject.FindGameObjectWithTag("Player") != null) {
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		rgbody = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
		if(!GameOverManager.gameOver) {
			Moving();
			SetAnim();

			if(attackTimeCounter <= 0f) {
				if(Vector2.Distance(target.position, transform.position) <= attackRange) {
					rgbody.velocity = Vector2.zero;
					isAttacking = true;
					attackTimeCounter = attackTime;
					attackAnimStopCounter = stopAnim;
				}
			}

			if(attackTimeCounter > 0f) {
				attackTimeCounter -= Time.deltaTime;
			}

			if(attackAnimStopCounter > 0f) {
				attackAnimStopCounter -= Time.deltaTime;
			} else {
				isAttacking = false;
			}
		} else {
			isMoving = false;
			isAttacking = false;
			SetAnim();
		}
	}

	void Moving() {
		if(attackTimeCounter <= 0f && Vector2.Distance(target.position, transform.position) > followRange) {
			isMoving = true;
			Vector2 dir = (target.position - transform.position).normalized;
			rgbody.velocity = dir * moveSpeed;
			lastMove = dir;
		} else {
			isMoving = false;
			rgbody.velocity = Vector2.zero;
		}
	}

	void SetAnim() {
		anim.SetBool("isMoving", isMoving);
		anim.SetBool("isAttacking", isAttacking);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}
}

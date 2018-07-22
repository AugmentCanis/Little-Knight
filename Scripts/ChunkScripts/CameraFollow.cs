using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector2 boundariesX, boundariesY;
	public float time;

	void FixedUpdate () {
		if(target == null) {
			return;
		}

		Vector3 destination = new Vector3(target.position.x, target.position.y, -10f);
		if(destination.x < boundariesX.x) 
			destination.x = boundariesX.x;
		else if(destination.x > boundariesX.y) 
			destination.x = boundariesX.y;
		
		if(destination.y < boundariesY.x) 
			destination.y = boundariesY.x;
		else if(destination.y > boundariesY.y) 
			destination.y = boundariesY.y;

		transform.position = Vector3.Lerp(transform.position, destination, time);
	}
}

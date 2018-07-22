using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour {

	public Transform reference;

	void Start() {
		reference = GameObject.Find("Reference").transform;
	}
	
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - reference.position.y);
	}
}

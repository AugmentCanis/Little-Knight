using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeCamera : MonoBehaviour {

	void Start () {
		CameraShaker.Instance.StartShake(2f, .1f, 1f);
	}
}

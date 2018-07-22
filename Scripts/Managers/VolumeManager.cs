using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

	void Update () {
		if(gameObject.tag == "Music") {
			gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume", 1f);
		} else if(gameObject.tag == "SoundEffect") {
			gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
		}
	}

	public void ChangeMusicVolume (float val) {
		PlayerPrefs.SetFloat("musicVolume", val);
	}

	public void ChangeSfxVolume (float val) {
		PlayerPrefs.SetFloat("sfxVolume", val);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolumeSliderValue : MonoBehaviour {

	void Start () {
		if(gameObject.tag == "Music") {
			gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicVolume", 1f);
		} else if(gameObject.tag == "SoundEffect") {
			gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("sfxVolume", 1f);
		}
	}
}

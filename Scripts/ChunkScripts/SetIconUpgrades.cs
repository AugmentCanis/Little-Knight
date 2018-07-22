using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetIconUpgrades : MonoBehaviour {

	public GameObject eventSystem;
	public GameObject sleeve, shield;

	void Start() {
		UpdateIcon();
	}

	public void UpdateIcon () {
		Upgrades upg = eventSystem.GetComponent<Upgrades>();
		Upgrades.Upgrade up;

		// Set health upgrades
		int hpUpg = PlayerPrefs.GetInt("healthUpgrade", 0);
		up = upg.GetUpgrade(hpUpg);
		sleeve.GetComponent<Image>().color = new Color(up.r / 255f, up.g / 255f, up.b / 255f); // Impart la 255 ca sa dau valoari intre 0 si 1


		// Set shield upgrades
		int guardUpg = PlayerPrefs.GetInt("shieldUpgrade", 0);
		up = upg.GetUpgrade(guardUpg);
		shield.GetComponent<Image>().color = new Color(up.r / 255f, up.g / 255f, up.b / 255f);
	}
}

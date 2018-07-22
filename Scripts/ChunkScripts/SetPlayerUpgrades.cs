using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerUpgrades : MonoBehaviour {

	public GameObject eventSystem;
	public GameObject health, guard;
	public GameObject sleeve, shield;

	void Awake () {
		Upgrades upg = eventSystem.GetComponent<Upgrades>();
		Upgrades.Upgrade up;

	
		// Set health upgrades
		int hpUpg = PlayerPrefs.GetInt("healthUpgrade", 0);
		up = upg.GetUpgrade(hpUpg);

		gameObject.GetComponent<Health>().maxHealth = up.val;
		RectTransform rt = health.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(up.val, rt.sizeDelta.y);
		sleeve.GetComponent<SpriteRenderer>().color = new Color(up.r / 255f, up.g / 255f, up.b / 255f); // Impart la 255 ca sa dau valoari intre 0 si 1


		// Set shield upgrades
		int guardUpg = PlayerPrefs.GetInt("shieldUpgrade", 0);
		up = upg.GetUpgrade(guardUpg);

		gameObject.GetComponent<Guard>().maxGuardSize = (int)(up.val * 1.5f);
		rt = guard.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(up.val * 2f, rt.sizeDelta.y);
		shield.GetComponent<SpriteRenderer>().color = new Color(up.r / 255f, up.g / 255f, up.b / 255f);
	}
}

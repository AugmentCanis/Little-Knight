using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopManager : MonoBehaviour {

	public Text moneyText;
	public GameObject confirmation;
	public Button backButton;
	public Weapon[] weapons;
	public Transform[] weaponsShop;

	void Start () {
		UpdateShop();
	}

	public void WeaponCheck(int weaponNo) {
		if(PlayerPrefs.GetInt("weaponNo" + weaponNo.ToString(), 0) == 0 && weaponNo != 0) {
			BuyWeapon(weaponNo);
		} else {
			PlayerPrefs.SetInt("weaponNo", weaponNo);
			backButton.interactable = true;
			UpdateShop();
			gameObject.GetComponent<SetIconUpgrades>().UpdateIcon();
		}
	}

	public void UpdateShop() {
		moneyText.text = PlayerPrefs.GetInt("money", 0).ToString(); 
		for(int weapon = 0; weapon < 9; ++weapon) {
			SetUpgrade(weapon);
		}
	}
	
	void SetUpgrade(int weaponNo) {
		Transform childPrice = weaponsShop[weaponNo].GetChild(0);
		Transform childImage = weaponsShop[weaponNo].GetChild(1);

		if(PlayerPrefs.GetInt("weaponNo", 0) == weaponNo) {
			childImage.GetChild(2).gameObject.SetActive(true);
		} else {
			childImage.GetChild(2).gameObject.SetActive(false);
		}

		if(PlayerPrefs.GetInt("weaponNo" + weaponNo.ToString(), 0) == 1) {
			childImage.GetChild(3).gameObject.SetActive(false);
			childPrice.gameObject.SetActive(false);
		} else if(weaponNo != 0) {
			childImage.GetChild(3).gameObject.SetActive(true);
			childPrice.gameObject.SetActive(true);
			childPrice.GetComponentInChildren<Text>().text = weapons[weaponNo].price.ToString();
		}
	}

	public void BuyWeapon(int weaponNo) {
		if(weaponNo != 1 && weaponNo != 5 && PlayerPrefs.GetInt("weaponNo" + (weaponNo - 1).ToString(), 0) == 0	
		|| weapons[weaponNo].price > PlayerPrefs.GetInt("money", 0)) {
			backButton.interactable = true;
			return;
		}
		
		confirmation.SetActive(true);
	}

	public void ConfirmUpgrade() {
		int weaponNo = int.Parse(confirmation.name);

		int money = PlayerPrefs.GetInt("money", 0) - weapons[weaponNo].price;
		PlayerPrefs.SetInt("money", money);
		PlayerPrefs.SetInt("weaponNo" + weaponNo.ToString(), 1);
		
		moneyText.text = money.ToString();
		gameObject.GetComponent<SetIconUpgrades>().UpdateIcon();
		UpdateShop();
	}
}

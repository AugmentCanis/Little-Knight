using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Text moneyText;
	public GameObject confirmation;
	public Button backButton;
	public Text hpPrice;
	public List<Button> hpButtons;
	public Text guardPrice;
	public List<Button> guardButtons;
	public Color upgradedColor;

	void Start () {
		UpdateShop();
	}

	void Update() {
		// hack 4 money
		if(Input.GetKeyDown(KeyCode.B)) {
			int money = PlayerPrefs.GetInt("money", 0) + 1000;
			PlayerPrefs.SetInt("money", money);
			moneyText.text = money.ToString();
		}
	}

	public void UpdateShop() {
		moneyText.text = PlayerPrefs.GetInt("money", 0).ToString(); 
		SetUpgrade("healthUpgrade", hpPrice,  hpButtons);
		SetUpgrade("shieldUpgrade", guardPrice, guardButtons);
	}
	
	void SetUpgrade(string upgradeName, Text price, List<Button> buttons) {
		int upg = PlayerPrefs.GetInt(upgradeName, 0);
		Upgrades.Upgrade upgrade = Upgrades.upgradeList[upg];
		price.text = upgrade.price;

		for(int i = 0; i < upg; ++i) {
			ColorBlock colors = buttons[i].colors;
			colors.disabledColor = upgradedColor;
			buttons[i].colors = colors;
		}
	}

	public void BuyUpgrade(string upgradeName) {
		int upg = PlayerPrefs.GetInt(upgradeName, 0);
		if(upg == 6) { 
			backButton.interactable = true;
			return;
		}
		Upgrades.Upgrade upgrade = Upgrades.upgradeList[upg];
		if(int.Parse(upgrade.price) > PlayerPrefs.GetInt("money", 0)) {
			backButton.interactable = true;
			return;
		}
		confirmation.SetActive(true);
	}

	public void ConfirmUpgrade() {
		string upgradeName = confirmation.name;

		int upg = PlayerPrefs.GetInt(upgradeName, 0);
		Upgrades.Upgrade upgrade = Upgrades.upgradeList[upg];

		int money = PlayerPrefs.GetInt("money", 0) - int.Parse(upgrade.price);
		PlayerPrefs.SetInt("money", money);
		PlayerPrefs.SetInt(upgradeName, upg + 1);
		
		moneyText.text = money.ToString();
		gameObject.GetComponent<SetIconUpgrades>().UpdateIcon();
		SetUpgrade("healthUpgrade", hpPrice,  hpButtons);
		SetUpgrade("shieldUpgrade", guardPrice, guardButtons);
	}	
}

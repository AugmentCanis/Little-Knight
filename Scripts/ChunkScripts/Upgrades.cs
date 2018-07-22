using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Upgrades : MonoBehaviour {

	public class Upgrade {
		public Upgrade(int _r, int _g, int _b, int _val, string _price) {
			r = _r;
			g = _g;
			b = _b;
			val = _val;
			price = _price;
		}

		public int r, g, b;
		public int val;
		public string price;
	};

	public static List<Upgrade> upgradeList;
	public TextAsset upgradeTextfile;

	public Upgrade GetUpgrade(int index) {
		return upgradeList[index];
	}
	
	void Awake () {
		// Take upgrades from file
		string text = upgradeTextfile.text;
		char[] sep = {'\n'};
		string[] upgradeText = text.Split(sep);

		upgradeList = new List<Upgrade>();
		for(int i = 0; i < upgradeText.Length; i += 6) {
			// Add element
			upgradeList.Add(new Upgrade(int.Parse(upgradeText[i]), int.Parse(upgradeText[i + 1]), int.Parse(upgradeText[i + 2]), int.Parse(upgradeText[i + 3]), upgradeText[i+ 4]));
		}
	}
}

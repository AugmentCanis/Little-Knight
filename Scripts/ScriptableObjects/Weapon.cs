using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {

	public Sprite image;
	public int price, attack;
	public float atkSpd, range;
}

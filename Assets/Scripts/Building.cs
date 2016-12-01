using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public string buildName;
	public GameObject preview;

	public int maxHealth = 0;
	int health = 0;

	public int resourceCost;

	void Start () {
		health = maxHealth;
	}

	void Damage (int amount) {
		this.health += amount;
		if (this.health > maxHealth) {
			this.health = maxHealth;
		} else if (this.health <= 0) {
			Destroy (this.gameObject);
		}
	}
}

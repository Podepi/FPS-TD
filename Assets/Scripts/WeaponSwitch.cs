using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	public Text equipText;
	public GameObject buildTool;
	public GameObject weapon01;
	public GameObject weapon02;
	public int current = 0;

	// Use this for initialization
	void Start () {
		SwitchToWeapon (0);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerBuildTool buildScript = gameObject.GetComponent <PlayerBuildTool> ();
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SwitchToWeapon (0);
			buildScript.buildPreview.SetActive (true);
			buildScript.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SwitchToWeapon (1);
			buildScript.buildPreview.SetActive (false);
			buildScript.enabled = false;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3) && weapon02 != null) {
			SwitchToWeapon (2);
			buildScript.buildPreview.SetActive (false);
			buildScript.enabled = false;
		}
		if (Input.GetAxis ("Fire1") == 1.0f) {
			if (current == 1) {
				weapon01.GetComponent<WeaponScript> ().Fire ();
			}
			else if (current == 1) {
				weapon02.GetComponent<WeaponScript> ().Fire ();
			}
		}
	}

	void SwitchToWeapon(int w) {
		current = w;
		switch (w) {
		case 0:
			buildTool.SetActive (true);
			weapon01.SetActive (false);
			weapon02.SetActive (false);
			equipText.text = "Build Tool";
			break;
		case 1:
			buildTool.SetActive (false);
			weapon01.SetActive (true);
			weapon02.SetActive (false);
			equipText.text = weapon01.name;
			break;
		case 2:
			buildTool.SetActive (false);
			weapon01.SetActive (false);
			weapon02.SetActive (true);
			equipText.text = weapon02.name;
			break;
		}
	}
}

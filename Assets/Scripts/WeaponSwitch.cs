using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	public Text equipText;
	public GameObject buildTool;
	public GameObject weapon01;
	public GameObject weapon02;
	public int currentWeapon = 0;

	// Use this for initialization
	void Start () {
	
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
	}

	void SwitchToWeapon(int w) {
		switch (w) {
		case 0:
			buildTool.SetActive (true);
			weapon01.SetActive (false);
			weapon02.SetActive (false);
			break;
		case 1:
			buildTool.SetActive (false);
			weapon01.SetActive (true);
			weapon02.SetActive (false);
			break;
		case 2:
			buildTool.SetActive (false);
			weapon01.SetActive (false);
			weapon02.SetActive (true);
			break;
		}
	}
}

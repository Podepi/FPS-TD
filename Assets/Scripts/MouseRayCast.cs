using UnityEngine;
using System.Collections;

public class MouseRayCast : MonoBehaviour {

	public GameObject buildPreview;
	public string equipped = "build";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DoRayCast ();

	}

	void DoRayCast() {
		Transform cam = Camera.main.transform;
		RaycastHit hit;
		if (Physics.Raycast (cam.position, cam.forward, out hit, 500)) {
			switch (equipped) {
			case "build":
				Vector3 snapVec = new Vector3 ();
				float gridSize = 2.0f;
				float offset = 0.5f;
				snapVec.x = (int)((hit.point.x / gridSize) + offset) * gridSize;
				snapVec.y = (int)((hit.point.y / gridSize) + offset) * gridSize;
				snapVec.z = (int)((hit.point.z / gridSize) + offset) * gridSize;
				buildPreview.gameObject.SetActive (true);
				buildPreview.transform.position = snapVec;
				break;
			}
		} else {
			switch (equipped) {
			case "build":
				buildPreview.gameObject.SetActive (false);
				break;
			}
		}
	}
}

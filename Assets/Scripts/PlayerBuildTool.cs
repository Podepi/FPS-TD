using UnityEngine;
using System.Collections;

public class PlayerBuildTool : MonoBehaviour {

	public GameObject buildPreview;
	public GameObject[] buildList;
	int buildSelect = 0;

	bool prevRotate = false;
	bool prevFire1 = false;
	bool prevFire2 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = DoRayCast ();

		buildSelect = (int)mod( buildSelect + (int)(Input.GetAxis ("Mouse ScrollWheel")*10),
			buildList.Length );
		
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			Debug.Log (buildSelect);
			GameObject oldPreview = buildPreview.transform.Find("preview").gameObject;
			GameObject newPreview = Instantiate (buildList [buildSelect].GetComponent<Building>().preview);
			newPreview.layer = 2;
			newPreview.name = "preview";
			newPreview.transform.parent = buildPreview.transform;
			newPreview.transform.localPosition = Vector3.zero;
			newPreview.transform.localRotation = Quaternion.Euler(Vector3.zero);
			Destroy (oldPreview);
		}

		if (Input.GetAxis ("Rotate") != 0) {
			if (!prevRotate) {
				Vector3 rot = buildPreview.transform.rotation.eulerAngles;
				rot.y += Input.GetAxis ("Rotate") * 90;
				buildPreview.transform.rotation = Quaternion.Euler (rot);
				prevRotate = true;
			}
			prevRotate = true;
		} else {
			prevRotate = false;
		}

		if (Input.GetAxis ("Fire1") != 0) {
			if (!prevFire1) {
				GameObject newBuilding = Instantiate (buildList [buildSelect]);
				newBuilding.transform.position = SnapVecToGrid(hit.point);
				newBuilding.transform.rotation = buildPreview.transform.rotation;
				prevFire1 = true;
			}
			prevFire1 = true;
		} else {
			prevFire1 = false;
		}

		if (Input.GetAxis ("Fire2") != 0) {
			if (!prevFire2) {
				GameObject obj = hit.collider.gameObject;
				Debug.Log (obj.tag);
				if (obj.tag == "Building") {
					Destroy (obj);
				}
			}
			prevFire2 = true;
		} else {
			prevFire2 = false;
		}
	}

	RaycastHit DoRayCast() {
		Transform cam = Camera.main.transform;
		RaycastHit hit;
		if (Physics.Raycast (cam.position, cam.forward, out hit, 500)) {
			Vector3 snapVec = SnapVecToGrid (hit.point);
			buildPreview.gameObject.SetActive (true);
			buildPreview.transform.position = snapVec;
		} else {
			buildPreview.gameObject.SetActive (false);
		}
		return (hit);
	}

	Vector3 SnapVecToGrid(Vector3 vec, float gridSize = 2.0f, float offset = 0.5f) {
		Vector3 snapVec = new Vector3 ();
		snapVec.x = (int)((vec.x / gridSize) + offset * Mathf.Sign(vec.x)) * gridSize;
		snapVec.y = (int)((vec.y / gridSize)) * gridSize;
		snapVec.z = (int)((vec.z / gridSize) + offset * Mathf.Sign(vec.z)) * gridSize;
		return (snapVec);
	}

	int mod(int x, int m) {
		return (x % m + m) % m;
	}

	float nfmod(float a, float b)
	{
		return a - b * Mathf.Floor(a / b);
	}
}

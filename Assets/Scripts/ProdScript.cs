using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProdScript : MonoBehaviour {

	public float force;

	void OnMouseDown()
	{
		gameObject.GetComponent<Rigidbody>().AddForce (new Vector3 (0, 0, force));
	}
}

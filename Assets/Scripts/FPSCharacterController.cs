using UnityEngine;
using System.Collections;

public class FPSCharacterController : MonoBehaviour {

	public float speed = 10.0f;
	public float jumpSpeed = 100.0f;
	public float gravMult = 1.0f;

	public Rigidbody rb;

	private float verticalVelocity = 0.0f;
	private Vector3 moveDirection = Vector3.zero;

	CharacterController cc;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), verticalVelocity, Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		if (cc.isGrounded) {
			verticalVelocity = 0;
			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpSpeed;
			}
		}
	}

	void FixedUpdate() {
		if (!cc.isGrounded) {
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		moveDirection.y = verticalVelocity;
		cc.Move (moveDirection * Time.deltaTime);
	}
}

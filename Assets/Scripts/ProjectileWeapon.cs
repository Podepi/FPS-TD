using UnityEngine;
using System.Collections;

public class ProjectileWeapon : WeaponScript {

	// GameObject to instantiate when Fire() called
	public GameObject projectile;

	// Transform to instantiate projectile at.
	// Location and rotation determine the direction
	// and position the projectile will be shot from
	public Transform launcher;

	// Force to apply to projectile
	public float speed = 1.0f;

	// Adds rotation force to prejectile
	public float torque = 0.0f;

	public float rechargeTime = 1.0f;
	float timeToRecharge = 0.0f;

	// Update is called once per frame
	void FixedUpdate () {
		timeToRecharge -= Time.deltaTime;
	}

	public override void Fire () {
		if (timeToRecharge < 0) {
			timeToRecharge = rechargeTime;
			GameObject clone = Instantiate (projectile);
			clone.transform.position = launcher.position;
			clone.transform.localRotation = launcher.localRotation;
			clone.GetComponent<Rigidbody> ().AddForce (launcher.forward * speed, ForceMode.VelocityChange);
			clone.GetComponent<Rigidbody> ().AddTorque (new Vector3 (torque, torque, torque));
		}
	}
}

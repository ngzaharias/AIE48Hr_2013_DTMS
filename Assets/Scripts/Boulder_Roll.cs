using UnityEngine;
using System.Collections;

public class Boulder_Roll : Triggerable {
	
	float xDirection = 1.0f;
	float speed = 0.0f;
	
	void FixedUpdate() {
		Vector3 velocity = transform.rigidbody.velocity;
		velocity.x = Mathf.Clamp(velocity.x + (speed * xDirection), -speed, speed);
		transform.rigidbody.velocity = velocity;
	}
	
	public override void ToggleOn() {
		speed = 12.0f;
	}
	
	public override void ToggleOff() {
		speed = 0.0f;
	}
}

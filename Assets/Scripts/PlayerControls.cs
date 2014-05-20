using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	public string Joystick = "Keyboard";
	public string JoystickJump = "Keyboard";
	public KeyCode Jump = KeyCode.Space;
	
	//	Controller for the Player **CANNOT HAVE RIGIDBODY OR COLLIDER**
	protected CharacterController controller;
	
	protected bool doubleJumped = false;
	
	float size = 0.0f;
	
	public float moveSpeed = 20.0f;
	public float jumpSpeed = 20.0f;
	
	protected Vector3 gravity = Vector3.zero;
	
	Vector3 movement = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		size = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		//	Check whether Gravity needs to be applied
		if (!IsGrounded()) {
			//gravity += Physics.gravity * Time.deltaTime;
		}
		else {
			gravity	= Vector3.zero;
			doubleJumped = false;
		}
		
		KeyboardInput();
		
		movement += gravity;
		Vector3 newPos = transform.position;
		newPos += movement * Time.deltaTime;
		transform.position = newPos;
	}
	
	void KeyboardInput() {
		movement = new Vector3(Input.GetAxis(Joystick), 0.0f, 0.0f);
		movement *= moveSpeed;
		
		Vector3 jumpVelocity = transform.rigidbody.velocity;
		if (Input.GetKeyDown(Jump)) {
			if (IsGrounded()) {
				jumpVelocity.y = jumpSpeed;
			}
			else if (!doubleJumped) {
				jumpVelocity.y = jumpSpeed;
				doubleJumped = true;
			}
		}
		transform.rigidbody.velocity = jumpVelocity;
	}
	
	bool IsGrounded() {
		if (Physics.Raycast(new Vector3(transform.position.x - size,transform.position.y,transform.position.z), -Vector3.up, size + 0.1f) ||
			Physics.Raycast(new Vector3(transform.position.x + size,transform.position.y,transform.position.z), -Vector3.up, size + 0.1f)) {
			return true;
		}
		return false;
	}
}

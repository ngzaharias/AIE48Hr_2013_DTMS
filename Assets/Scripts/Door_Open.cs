using UnityEngine;
using System.Collections;

public class Door_Open : Triggerable {
	
	Transform body;
	
	public float direction = -1;
	
	bool opened = false;
	Vector3 startPos;
	Vector3 endPos;
	
	float speed = 0.05f;
	
	// Use this for initialization
	void Start () {
		body = transform.GetChild(0);
		float drSize = body.collider.bounds.extents.y;
		startPos = transform.position;
		endPos = startPos + (new Vector3(0,(drSize*direction*2)*0.9f,0));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position;
		if (opened) {
			newPos = Vector3.Lerp(newPos, endPos, speed);
		}
		else {
			newPos = Vector3.Lerp(newPos, startPos, speed);
		}
		transform.position = newPos;
	}
	
	public override void ToggleOn() 
	{
		opened = true;
	}
	
	public override void ToggleOff() {
		opened = false;	
	}
}

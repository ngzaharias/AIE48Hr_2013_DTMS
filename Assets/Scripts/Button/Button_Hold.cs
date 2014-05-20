using UnityEngine;
using System.Collections;

public class Button_Hold : MonoBehaviour {

	public Transform triggerObject;
	public Transform switchBase;
	public Transform switchButton;
	public Transform switchTrigger;
	
	bool pressed = false;
	Vector3 startPos;
	Vector3 endPos;
	
	float speed = 0.35f;
	
	// Use this for initialization
	void Start () {
		
		float btnSize = switchButton.collider.bounds.extents.y;
		startPos = switchButton.transform.position;
		endPos = startPos - new Vector3(0,btnSize * 0.4f,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	
	void Update() {
		Vector3 newPos = switchButton.transform.position;
		if (pressed) {
			newPos = Vector3.Lerp(newPos, endPos, speed);
		}
		else {
			newPos = Vector3.Lerp(newPos, startPos, speed);
		}
		switchButton.transform.position = newPos;
		
		pressed = switchTrigger.GetComponent<Button_Trigger>().pressed;
		if (pressed)
			triggerObject.GetComponent<Triggerable>().ToggleOn();
		else 
			triggerObject.GetComponent<Triggerable>().ToggleOff();
	}
}

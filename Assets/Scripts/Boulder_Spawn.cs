using UnityEngine;
using System.Collections;

public class Boulder_Spawn : Triggerable {
	
	public GameObject boulder_Prefab;
	
	float lastTime = 0.0f;
	float delay = 2.5f;
	
	bool butPressed = false;
	
	public override void ToggleOn() {
		butPressed = true;
		if (butPressed && Time.time > lastTime + delay) {
			Instantiate(boulder_Prefab, transform.position, boulder_Prefab.transform.rotation);
			lastTime = Time.time;
			Debug.Log("Bould Spawn");
		}
	}
	
	public override void ToggleOff() {
		butPressed = false;
	}
}

using UnityEngine;
using System.Collections;

public class Button_Trigger : MonoBehaviour {
	
	public bool pressed = false;
	public string triggerTag = "Player";
	
	void OnTriggerEnter (Collider other) {
		if (other.transform.tag == 	triggerTag) {
			pressed = true;	
		}
	}
	
	void OnTriggerExit (Collider other) {
		if (other.transform.tag == 	triggerTag) {
			pressed = false;	
		}
	}
}

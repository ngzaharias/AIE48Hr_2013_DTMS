using UnityEngine;
using System.Collections;

public class Triggerable : MonoBehaviour{
	
	public bool pressed = false;
	
	public virtual void ToggleOn() {
		pressed = true;
	}
	
	public virtual void ToggleOff() {
		pressed = false;
	}
}

using UnityEngine;
using System.Collections;

public class Animation_Stop : Triggerable {

	public override void ToggleOn() 
	{
		animation.Stop();
		if (transform.GetChildCount() != 0) {
			for (int i = 0; i < transform.GetChildCount(); ++i) {
				if (transform.GetChild(i).animation)
					transform.GetChild(i).animation.Stop ();
			}
		}
	}
	
	public override void ToggleOff() {
		if (!pressed) {
			animation.Play();
			if (transform.GetChildCount() != 0) {
				for (int i = 0; i < transform.GetChildCount(); ++i) {
					if (transform.GetChild(i).animation)
						transform.GetChild(i).animation.Play();
				}
			}
		}
	}
}

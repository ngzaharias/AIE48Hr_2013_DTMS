using UnityEngine;
using System.Collections;

public class Win_Get_Stick : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		
		if (other.transform.tag == "Player") {			
			Invoke("Win",2.0f);
		}
	}
	
	void Win() {
		Application.LoadLevel(2);	
	}
}

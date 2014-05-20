using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Player") {
			Application.Quit();
		}
	}
}

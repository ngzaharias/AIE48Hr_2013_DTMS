using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	
	public string nextLevel;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {
		if (player.transform.tag == "Player") {
			Application.LoadLevel(nextLevel);
		}
	}
}

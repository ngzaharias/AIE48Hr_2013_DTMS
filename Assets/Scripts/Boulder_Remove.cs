using UnityEngine;
using System.Collections;

public class Boulder_Remove : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);	
	}
}

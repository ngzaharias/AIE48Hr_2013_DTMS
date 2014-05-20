using UnityEngine;
using System.Collections;

public class Level_01_Zone01 : MonoBehaviour {
	
	public Transform[] EntryDoors;
	
	float last = 0.0f;
	float delay = 0.1f;
	int i = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > last + delay) {
			if (i < EntryDoors.Length) {
				EntryDoors[i].GetComponent<Triggerable>().ToggleOn();
				last = Time.time;
				i++;
			}
		}
	}
}

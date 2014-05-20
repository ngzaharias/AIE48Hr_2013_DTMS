using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	List<GameObject> players = new List<GameObject>();
	
	bool solo = false;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.GetChildCount(); ++i) {
			players.Add(transform.GetChild(i).gameObject);	
		}
		
		if (transform.GetChildCount() < 2) {
			solo = true;	
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckWinner();
		
		Vector3 min = Camera.mainCamera.transform.position; 
		Vector3 max = Camera.mainCamera.transform.position;
		
		for (int i = 0; i < players.Count; i++) {
			min = Vector3.Min(players[i].transform.position, min);
			max = Vector3.Max(players[i].transform.position, max);
		}
		
		Vector3 midway = Vector3.Lerp(min, max, 0.5f);
		Vector3 camPos = Camera.mainCamera.transform.position;
		camPos.x = Mathf.Lerp(camPos.x, midway.x, 0.04f);
		camPos.y = Mathf.Lerp(camPos.y, midway.y, 0.1f) + 0.35f;
		Camera.mainCamera.transform.position = camPos;
	}
	
	public void RemovePlayer(GameObject player) {
		players.Remove(player);
	}
	
	void CheckWinner() {
		if (transform.GetChildCount() < 2 && !solo) {
			Application.LoadLevel(1);
		}
	}
}

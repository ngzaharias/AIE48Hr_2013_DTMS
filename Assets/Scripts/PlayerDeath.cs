using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	
	public ParticleSystem particles;
	
	bool dead = false;
		
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Death")
			BoomTown();
	}
	
	void BoomTown() {
		if (!dead) {
			dead = true;
			particles = Instantiate(particles,transform.position, transform.rotation) as ParticleSystem;
			//particles.Play();
			transform.parent.GetComponent<GameManager>().RemovePlayer(gameObject);
			Destroy(gameObject);
		}
	}
	
	void Update() {
		
	}
}

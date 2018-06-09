using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D trigger){

		if (trigger.gameObject.name.StartsWith("Ball")) {

			ObjectManager.Shared.DisableGameObject(trigger.gameObject);

			// Destroy() works after current frame
			if (ObjectManager.Shared.BallsActiveCount() == 0) {

				levelManager.LoadLevel("Lose Screen");
			}
		} else if (trigger.gameObject.name.StartsWith("PowerDrop")) {

			Destroy(trigger.gameObject);
		}
	}

	// not being used when it is triggered
	void OnCollisionEnter2D(Collision2D collision){
		print ("collision");
	}
}

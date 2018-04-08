using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public int maxHits;
	
	private LevelManager levelManager;
	private int timesHit;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager=GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timesHit>=maxHits){
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		timesHit++;
		//SimulateWin();
	}
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}

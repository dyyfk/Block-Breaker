using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool gameStart;
	private Vector3 paddleToBallDistance;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallDistance = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//print(paddleToBallDistance);
		if(!gameStart){
		  	//lock the position of the ball relative to the paddle
			this.transform.position = paddle.transform.position+paddleToBallDistance;
			if(Input.GetMouseButtonDown(0)){
				//launch the ball now 
				//print("Left click"); // testing 
				gameStart = true;
				this.rigidbody2D.velocity = new Vector2(2f,10f);
				}
			}
		}
}

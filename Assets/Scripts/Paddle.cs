using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	// Update is called once per frame
	void Update () {

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mouseInputX = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mouseInputX, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	public float GetLength() {
		return transform.localScale.x;
	}

	public void ExpandByLength(float length) {

		if (GetLength() + length <= Constants.Brick.PaddleLengthMax) {
			transform.localScale += new Vector3(length, 0, 0);
		}
	}

	public void ShrinkByLength(float length) {

		if (GetLength() - length > Constants.Brick.PaddleLengthMin) {
			transform.localScale -= new Vector3(length, 0, 0);
		}
	}
}

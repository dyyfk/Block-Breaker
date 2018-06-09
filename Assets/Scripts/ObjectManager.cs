using System.Linq;
using UnityEngine;

public class ObjectManager: MonoBehaviour {
	public static ObjectManager Shared = null;

	private static Ball _ballPrefab;
	private static Paddle _paddlePrefab;
	private static PowerDrop _powerDropPrefab;

	public Ball[] Balls;

    void Awake() {

	    if (Shared == null) {
		    Shared = this;
	    }

	    _ballPrefab = Resources.Load<Ball>("Ball");

	    Balls = new Ball[Constants.Ball.CountMax];
	    for (int i = 0; i < Constants.Ball.CountMax; i++) {

		    Balls[i] = _makeBallInactive();
	    }

	    Shared.AddBall();

	    _paddlePrefab = Resources.Load<Paddle>("Paddle");
	    _powerDropPrefab = Resources.Load<PowerDrop>("PowerDrop");
    }

	private static Ball _makeBallInactive() {

		var position = Vector3.zero;
		var ball = Instantiate(_ballPrefab, position, Quaternion.identity);
		ball.gameObject.SetActive(false);
		ball.gameObject.layer = 8; // Ball layer, for ignoring collision
		return ball;
	}

	public void AddBall() {

		var ball = Balls.FirstOrDefault(current => !current.gameObject.activeSelf);
		if (ball == null) { return; }

		// @todo: Change the logic after we implement the ability to have multiple paddles.
		// Maybe put the ball on the middle paddle or something.
        var paddles = FindObjectsOfType<Paddle>();
		var position = paddles[0].transform.position;
		position += new Vector3(0, 0.3f, 0);

		ball.transform.position = position;
		ball.gameObject.SetActive(true);
	}

	public void DisableGameObject(GameObject gameObj) {

		gameObj.SetActive(false);
	}

	public void MakePowerDrop(BricksType type, Vector3 position) {

		var power = Instantiate(_powerDropPrefab, position, Quaternion.identity);
		power.SetType(type);
	}

	public int BallsActiveCount() {

        var balls = FindObjectsOfType<Ball>();

		return balls.Count(ball => ball.gameObject.activeSelf);
	}

	public void ExpandAllBallsDiamaterByLength(float length) {

        var balls = FindObjectsOfType<Ball>();
		foreach (var ball in balls) {

			ball.ExpandDiamaterByLength(length);
		}
	}

	public void ShrinkAllBallsDiamaterByLength(float length) {

        var balls = FindObjectsOfType<Ball>();
		foreach (var ball in balls) {

			ball.ShrinkDiamaterByLength(length);
		}
	}

	public void ExpandAllPaddlesByLength(float length) {

        var paddles = FindObjectsOfType<Paddle>();
		foreach (var paddle in paddles) {

			paddle.ExpandByLength(length);
		}
	}

	public void ShrinkAllPaddlesByLength(float length) {

        var paddles = FindObjectsOfType<Paddle>();
		foreach (var paddle in paddles) {

			paddle.ShrinkByLength(length);
		}
	}
}

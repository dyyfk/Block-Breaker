using UnityEngine;

public class PowerDrop: MonoBehaviour {

    private TextMesh _textMesh;
    private Rigidbody2D _rigidbody;

    private string _text;
    public string Text {
        get { return _text; }
        set {
            _text = value;
            _textMesh.text = value;
        }
    }

    public BricksType Type;

    public void SetType(BricksType type) {

        Type = type;
        switch (type) {

            case BricksType.ShrinkBall:
                Text = "SB";
                break;
            case BricksType.ShrinkPaddle:
                Text = "SP";
                break;
            case BricksType.ExpandBall:
                Text = "EB";
                break;
            case BricksType.ExtendPaddle:
                _textMesh.text = "EP";
                break;
            case BricksType.AddBall:
                Text = "B";
                break;
        }
    }

	void OnTriggerEnter2D(Collider2D trigger) {

	    if (trigger.gameObject.name.StartsWith("Paddle")) {

		    TriggerPowerup();
		    Destroy(gameObject);
	    }
	}

    void TriggerPowerup() {

		switch (Type) {

			case BricksType.ExtendPaddle: {

				ObjectManager.Shared.ExpandAllPaddlesByLength(Constants.Brick.PaddleLengthIncrement);
				break;
			}

			case BricksType.ShrinkPaddle: {

				ObjectManager.Shared.ShrinkAllPaddlesByLength(Constants.Brick.PaddleLengthIncrement);
				break;
			}

			case BricksType.ExpandBall: {

				ObjectManager.Shared.ExpandAllBallsDiamaterByLength(Constants.Brick.BallSizeIncrement);
				break;
			}

			case BricksType.ShrinkBall: {

				ObjectManager.Shared.ShrinkAllBallsDiamaterByLength(Constants.Brick.BallSizeIncrement);
				break;
			}

			case BricksType.AddBall: {

				ObjectManager.Shared.AddBall();
				break;
			}
		}
    }

    private void Awake() {
        _textMesh = GetComponent<TextMesh>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.velocity = new Vector2(0f, -2.0f);
    }
}

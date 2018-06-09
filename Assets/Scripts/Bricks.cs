using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public int maxHits;

	public BricksType bricksType;
	
	private LevelManager levelManager;

	private int timesHit;

	private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		_spriteRenderer = GetComponent<SpriteRenderer>();

		Mutate();
	}

	// @todo: make each kind of mutation have individual probability on top of the general one.
	// For example, extending the paddle should be more common than adding a ball.
	// And negative effects - shrinks, or maybe instant death - should be a bit more rare.
	/// Determin whether this block can mutate into a special block, and mutate accordingly
	private void Mutate() {

		var can = Random.Range(0, 100);
		if (can >= 0 && can < Constants.Brick.MutationProbability) {

			// @todo: make this constant
			var type = Random.Range(1, System.Enum.GetValues(typeof(BricksType)).Length);
//			var type = Random.Range(1, 1);
			bricksType = (BricksType) type;
		} else {
			bricksType = BricksType.Normal;
		}

		switch (bricksType) {

			// @todo: Get better sprite
			case BricksType.ExtendPaddle:
				_spriteRenderer.color = Color.cyan;
				break;
			case BricksType.ShrinkPaddle:
				_spriteRenderer.color = Color.magenta;
				break;
			case BricksType.ExpandBall:
				_spriteRenderer.color = Color.white;
				break;
			case BricksType.ShrinkBall:
				_spriteRenderer.color = Color.green;
				break;
			case BricksType.AddBall:
				_spriteRenderer.color = Color.grey;
				break;
		}
	}

	// Update is called once per frame
	void Update () {

		if(timesHit >= maxHits){

			CheckMutation();
			Destroy(gameObject);
		}
	}

	/// <summary>
	///  Check if this Brick is mutated, and drop the powerup
	/// </summary>
	private void CheckMutation() {

		switch (bricksType) {

			case BricksType.ExtendPaddle: {

				ObjectManager.Shared.MakePowerDrop(BricksType.ExtendPaddle, transform.position);
				break;
			}

			case BricksType.ShrinkPaddle: {

				ObjectManager.Shared.MakePowerDrop(BricksType.ShrinkPaddle, transform.position);
				break;
			}

			case BricksType.ExpandBall: {

				ObjectManager.Shared.MakePowerDrop(BricksType.ExpandBall, transform.position);
				break;
			}

			case BricksType.ShrinkBall: {

				ObjectManager.Shared.MakePowerDrop(BricksType.ShrinkBall, transform.position);
				break;
			}

			case BricksType.AddBall: {

				ObjectManager.Shared.MakePowerDrop(BricksType.AddBall, transform.position);
				break;
			}
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

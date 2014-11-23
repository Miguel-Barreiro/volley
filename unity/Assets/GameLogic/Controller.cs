using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Text leftScoreLabel;
	public Text rightScoreLabel;

	public GameObject leftTopTarget;
	public GameObject leftBotTarget;
	public GameObject rightTopTarget;
	public GameObject rightBotTarget;

	public GameObject leftField;
	public GameObject rightField;

	public GameObject ballTemplate;


	// Use this for initialization
	void Start () {
		StartCoroutine("spawnBall");
	}
	IEnumerator spawnBall(){
		Debug.Log("reset ");
		yield return new WaitForSeconds(1f);
		Debug.Log("reset 2");
		this.resetBall();
	}

	void resetBall(){
		if ( ball != null){
			Destroy(ball);
		}
		ball = (GameObject)Instantiate(ballTemplate);
		ball.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		leftScoreLabel.text = this.scoreLeft.ToString();
		rightScoreLabel.text = this.scoreRight.ToString();
	}

	public void Restart(){
		Debug.Log("restart");
		//Application.LoadLevel("GameScene");
		resetBall();
		this.scoreLeft = 0;
		this.scoreRight = 0;
	}

	public void handleTargetCollision(GameObject target){
		if ( target == leftTopTarget){
			this.hitTopLeft();
		}else if ( target == leftBotTarget){
			this.hitBotLeft();
		}else if ( target == rightTopTarget){
			this.hitTopRight();
		}else if ( target == rightBotTarget){
			this.hitBotRight();
		}
		resetBall();
	}


	public void handleFieldCollision(GameObject field){
		if ( field == leftField ){
			this.ballFallLeft();
		}else if ( field == rightField ){
			this.ballFallRight();
		}
		resetBall();
	}

	public void ballFallLeft(){
		this.scoreRight += 3;
	}

	public void ballFallRight(){
		this.scoreLeft += 3;
	}


	public void hitTopLeft(){
		this.scoreRight += 1;
	}
	public void hitBotLeft(){
		this.scoreRight += 2;
	}
	public void hitTopRight(){
		this.scoreLeft += 1;
	}
	public void hitBotRight(){
		this.scoreLeft += 2;
	}

	private int scoreLeft = 0;
	private int scoreRight = 0;

	private GameObject ball;
}

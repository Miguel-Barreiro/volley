using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Text leftScoreLabel;
	public Text rightScoreLabel;

	public GameObject leftBotTarget;
	public GameObject rightBotTarget;

	public GameObject fieldLimit;

	public GameObject leftField;
	public GameObject rightField;

	public GameObject leftPlayer;
	public GameObject rightPlayer;

	public GameObject ballTemplate;

	public int MaxScore = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine("spawnBall");
	}
	IEnumerator spawnBall(){
		if (!isReseting){
			isReseting = true;
			yield return new WaitForSeconds(3f);
			this.resetBall();
			isReseting = false;
		}
	}

	IEnumerator spawnNewBall(){
		if (!isReseting){
			isReseting = true;

			yield return new WaitForSeconds(1f);
			this.resetBall();
			isReseting = false;
		}
	}

	IEnumerator FinishGame(){
		if (!isReseting){
			isReseting = true;
			if ( ball != null){
				Destroy(ball);
			}
			yield return new WaitForSeconds(4f);
			this.Restart();
			isReseting = false;
		}
	}

	private void checkScore(){
		if( this.scoreLeft >= MaxScore || this.scoreRight >= MaxScore){
			StartCoroutine("FinishGame");
		}else{
			StartCoroutine("spawnNewBall");
		}
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
		if( isReseting) return;

		if ( target == leftBotTarget){
			this.hitBotLeft();
		}else if ( target == rightBotTarget){
			this.hitBotRight();
		}

		checkScore();
	}

	public void handleFieldCollision(GameObject field){
		if( isReseting) return;
		if ( field == leftField ){
			this.ballFallLeft();
		}else if ( field == rightField ){
			this.ballFallRight();
		}
		checkScore();
	}

	public void handlePLayerCollision(GameObject player){
		lastPlayerHit = player;
	}

	public void handleFieldLimitCollision(){
		if ( this.lastPlayerHit == this.leftPlayer ){
			this.scoreRight += 1;
		}else if( this.lastPlayerHit == this.leftPlayer ){
			this.scoreLeft += 1;
		}
		checkScore();
	}


	public void ballFallLeft(){
		this.scoreRight += 1;
	}

	public void ballFallRight(){
		this.scoreLeft += 1;
	}


	public void hitTopLeft(){
	}
	public void hitBotLeft(){
		this.scoreRight += 2;
	}
	public void hitTopRight(){
	}
	public void hitBotRight(){
		this.scoreLeft += 2;
	}

	private GameObject lastPlayerHit = null;

	private int scoreLeft = 0;
	private int scoreRight = 0;

	private GameObject ball;
	private bool isReseting = false;
}

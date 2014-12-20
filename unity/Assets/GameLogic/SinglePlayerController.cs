using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SinglePlayerController : MonoBehaviour {

	public Text scoreLabel;

	public GameObject fieldLimit;

	public FieldController floor;

	public playerController leftPlayer;
	public playerController rightPlayer;

	public GameObject ballTemplate;

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
	
	void resetBall(){
		if ( ball != null){
			Destroy(ball);
		}
		ball = (GameObject)Instantiate(ballTemplate);
		ball.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = this.score.ToString();
	}

	public void Restart(){
		Debug.Log("restart");
		//Application.LoadLevel("GameScene");
		resetBall();
		this.score = 0;
	}


	public void handlePLayerCollision(GameObject player){
		if ( player != lastPlayerHit){
			this.score = this.score + 1;
		}
		lastPlayerHit = player;
	}

//	private void checkScore(){
//		if( this.scoreLeft >= MaxScore || this.scoreRight >= MaxScore){
//			StartCoroutine("FinishGame");
//		}else{
//			StartCoroutine("spawnNewBall");
//		}
//	}

	private int score = 0;
	
	private GameObject lastPlayerHit = null;
	private GameObject ball;
	private bool isReseting = false;
}

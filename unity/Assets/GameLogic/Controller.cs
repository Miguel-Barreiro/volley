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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		leftScoreLabel.text = this.scoreLeft.ToString();
		rightScoreLabel.text = this.scoreRight.ToString();
	}

	public void Restart(){
		Application.LoadLevel("GameScene");
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
	}

	public void hitTopLeft(){
		this.scoreLeft += 1;
	}
	public void hitBotLeft(){
		this.scoreLeft += 2;
	}
	public void hitTopRight(){
		this.scoreLeft += 1;
	}
	public void hitBotRight(){
		this.scoreLeft += 2;
	}

	private int scoreLeft = 0;
	private int scoreRight = 0;
}

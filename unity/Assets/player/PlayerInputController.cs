using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(playerController))]
public class PlayerInputController : MonoBehaviour {

	void Start () {
		_playerController = GetComponent<playerController>();
	}
	
	void Update () {
		if(Input.touchCount > 0 && this._playerController.IsGrounded()){
			Vector2 currentPositionScreen = Camera.main.WorldToScreenPoint(transform.position);
			
			Touch[] myTouches = Input.touches;
			for( int i = 0; i < myTouches.Length; i++){
				//Touch touch = Input.GetTouch(i);
				Touch touch = myTouches[i];
				Debug.Log(touch.fingerId);

				if ( (currentPositionScreen.x > Screen.width / 2 && touch.position.x > Screen.width / 2 ) || 
				    ( currentPositionScreen.x < Screen.width / 2 && touch.position.x < Screen.width / 2)){
					if ( touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved){
						controlCharacter(touch);
					}
				}
			}
		}
	}

	private void controlCharacter(Touch touch){
		Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);
		this._playerController.action(target);
		fingerId = touch.fingerId;
	}

	void OnMouseUp(){
//		_playerController.jump();
	}

	private int fingerId = -1;
	private playerController _playerController;
}

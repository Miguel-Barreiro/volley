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
		if(Input.touchCount > 0 && isGrounded){
			Vector2 currentPositionScreen = Camera.main.WorldToScreenPoint(transform.position);
			
			Touch[] myTouches = Input.touches;
			for( int i = 0; i < myTouches.Length; i++){
				//Touch touch = Input.GetTouch(i);
				Touch touch = myTouches[i];
				/*
				Debug.Log(" tcurrentPositionScreen.x > Screen.width = " + (currentPositionScreen.x > Screen.width));
				Debug.Log(" touch.position.x > Screen.width / 2 = " + (touch.position.x > Screen.width / 2));
				Debug.Log(" tcurrentPositionScreen.x < Screen.width / 2 = " + (currentPositionScreen.x < Screen.width / 2));
				Debug.Log(" touch.position.x < Screen.width / 2 = " + (touch.position.x < Screen.width / 2));

				Debug.Log(touch.fingerId);
*/
				if ( (currentPositionScreen.x > Screen.width / 2 && touch.position.x > Screen.width / 2 ) || 
				    ( currentPositionScreen.x < Screen.width / 2 && touch.position.x < Screen.width / 2)){
					
					if ( touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began ){
						Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);
						this.action(target);
						fingerId = touch.fingerId;
					}/*else if( touch.phase == TouchPhase.Ended && this.isGrounded){
						this.jump();
						this.isGrounded = false;
					}
					*/
				}
			}
		}
	}

	void OnMouseUp(){
//		_playerController.jump();
	}

	private playerController _playerController;
}

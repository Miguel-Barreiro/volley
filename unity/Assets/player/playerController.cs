using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

	public float jumpForce = 600.0f;

	// Use this for initialization
	void Start () {
		body = (Rigidbody2D)GetComponent<Rigidbody2D>();
		isGrounded = false;
	}

	public void action( Vector3 targetPosition){
		if ( isGrounded ){
			target = new Vector2( targetPosition.x, transform.position.y);
		}
	}

	void FixedUpdate() {
		if (isGrounded)
			body.MovePosition(Vector3.Lerp(transform.position, target, Time.deltaTime));
	}

	public void setGrounded(bool grounded){
		isGrounded = grounded;
		target = transform.position;
	}

	void Update() {
		if(Input.touchCount > 0 && isGrounded){
			Vector2 currentPositionScreen = Camera.main.WorldToScreenPoint(transform.position);

			for( int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				if ( (currentPositionScreen.x > Screen.width / 2 && touch.position.x < Screen.width / 2 ) || 
				    ( currentPositionScreen.x < Screen.width / 2 && touch.position.x < Screen.width / 2)){

					if ( touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began ){
						Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);
						this.action(target);
						fingerId = touch.fingerId;
					}else if( touch.phase == TouchPhase.Ended && this.isGrounded){
						this.jump();
						this.isGrounded = false;
					}
				}
			}
		}
		/*
		else if (Input.GetMouseButtonDown(0) && this.isGrounded) {
			this.jump();
			this.isGrounded = false;
		}
		*/
/*
			Vector2 currentPositionScreen = Camera.main.WorldToScreenPoint(transform.position);
			
			if(( currentPositionScreen.x > Screen.width / 2 && Input.mousePosition.x > Screen.width/2) ||
			   ( currentPositionScreen.x < Screen.width / 2 && Input.mousePosition.x < Screen.width/2) ){
				Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				this.action(target);
			}

		}
*/		 

//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
//			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//			transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
//		}
	}
	
	
	public void jump(){
		body.AddForce(new Vector2(0.0f, jumpForce));
	}

	private bool isGrounded = false;
	private int fingerId = -1;
	private Vector2 target; 
	private Rigidbody2D body;


}

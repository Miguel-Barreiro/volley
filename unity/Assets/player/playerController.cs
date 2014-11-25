using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

	public float jumpForce = 300.0f;
	public float speed = 2;

	// Use this for initialization
	void Start () {
		body = (Rigidbody2D)GetComponent<Rigidbody2D>();
		isGrounded = false;
	}

	public void action( Vector3 targetPosition){
		Debug.Log( this.gameObject.name + ":action :" + targetPosition + " " + transform.position);
		if ( isGrounded ){
			//target = new Vector2( targetPosition.x, transform.position.y);
			Vector3 realTarget = targetPosition - transform.position;
//			realTarget.Normalize();
			body.velocity = new Vector2( realTarget.x * speed * 10, body.velocity.y);
		}
	}

	void FixedUpdate() {
	//	Vector3 realTarget = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
	//	body.AddForce(new Vector2(realTarget.x,realTarget.y));
	}

	public void setGrounded(bool grounded){
		isGrounded = grounded;
		target = transform.position;
	}

	void Update() {}
	
	
	public void jump(){
		body.AddForce(new Vector2(0.0f, jumpForce));
		this.isGrounded = true;
	}

	public bool IsGrounded(){
		return this.isGrounded;
	}

	private bool isGrounded = false;
	private Vector2 target; 
	private Rigidbody2D body;


}

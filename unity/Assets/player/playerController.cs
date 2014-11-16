using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour {

	public float jumpForce = 300.0f;

	// Use this for initialization
	void Start () {
		body = (Rigidbody2D)GetComponent<Rigidbody2D>();
		Debug.Log(body);
	}


	public void jump(){
		body.AddForce(new Vector2(0.0f, jumpForce));
	}

	private Rigidbody2D body;

}

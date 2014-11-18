using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class FieldController : MonoBehaviour {

	public Controller gameLogic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleFieldCollision(gameObject);
		}
	}

}

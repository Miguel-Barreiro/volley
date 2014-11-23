using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class FieldController : MonoBehaviour {

	public Controller gameLogic;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleFieldCollision(gameObject);
		}
	}

}

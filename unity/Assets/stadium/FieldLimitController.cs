using UnityEngine;
using System.Collections;

public class FieldLimitController : MonoBehaviour {

	public Controller gameLogic;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleFieldLimitCollision();
		}
	}

}

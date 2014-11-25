using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class TargetController : MonoBehaviour {

	public Controller gameLogic;

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log(coll.gameObject.tag);
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleTargetCollision(gameObject);
		}
	}
}

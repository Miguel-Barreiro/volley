using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class TargetController : MonoBehaviour {

	public Controller gameLogic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log(coll.gameObject.tag);
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleTargetCollision(gameObject);
		}
	}
}

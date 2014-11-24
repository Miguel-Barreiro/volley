﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class FieldController : MonoBehaviour {

	public Controller gameLogic;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "ballBody"){
			gameLogic.handleFieldCollision(gameObject);
		}
	}

}

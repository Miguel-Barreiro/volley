using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class GroundCheck : MonoBehaviour {

	public playerController player;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground"){
			player.setGrounded(true);
		}
	} 

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground"){
			player.setGrounded(false);
		}
	} 

}


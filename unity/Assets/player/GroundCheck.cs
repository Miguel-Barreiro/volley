using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class GroundCheck : MonoBehaviour {

	public playerController player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground"){
			Debug.Log("grounded");
			player.setGrounded(true);
		}
	} 

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground"){
			Debug.Log("jumping");
			player.setGrounded(false);
		}
	} 

}


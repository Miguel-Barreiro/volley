using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(playerController))]
public class PlayerInputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_playerController = GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		_playerController.jump();
	}

	private playerController _playerController;
}

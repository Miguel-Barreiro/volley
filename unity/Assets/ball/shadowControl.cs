using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class shadowControl : MonoBehaviour {

	public Transform ballBody;
	public Transform floor;

	private float maxHeightDifference;

	public void Awake() {
		this.maxHeightDifference = ballBody.position.y - floor.position.y;
	}



	void Update () {
		transform.position = new Vector3(ballBody.position.x,transform.position.y,0);
		float newScale = (ballBody.position.y - floor.position.y) / this.maxHeightDifference + 0.5f;
		transform.localScale = new Vector3(newScale, 1, 1);
//		Debug.Log(ballBody.position.y);

	}
}

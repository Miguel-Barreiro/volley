using UnityEngine;
using System.Collections;

public class shadowControl : MonoBehaviour {

	public Transform ballBody;

	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(ballBody.position.x,transform.position.y,0);
	}
}

using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jumpseed = 240f;
	public float forwardspeed = 20;

	private Rigidbody2D body2d;
	private InputState inputState;


	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inputState.standing) {
			if(inputState.activeButton){
				body2d.velocity = new Vector2(transform.position.x < 0 ? forwardspeed : 0, jumpseed);
			}
		}
	}
}

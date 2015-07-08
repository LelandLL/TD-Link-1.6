using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Jumping
	
	public int jumpStrength;    //how much energy can the player jump
	public int forceToAdd;      // The amount of upward force
	public int forceToAddDown;  // The amount of downward force
	
	protected float distanceTraveled = 0;
	public float distanceToAdd = 100f;
	
	bool jumping = false;
	bool addMoreForce = false;
	bool nextJump = false;
	
	protected int credits = 0;
	
	// Various internal stuff
	bool detectCollision = false; // Determines when a jump ends and another can begin. See below
	float centerXPos; 	
	
	// Use this for initialization
	void Start () {
		
		centerXPos = transform.position.x;
		
	}
	public void Jump()
	{
		float adjustedHeight = jumpStrength;
		
		jumping = true;
		addMoreForce = true;
		detectCollision = false;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("up")) {
			if (!jumping) {
				Jump ();
			} else {
				nextJump = true;
			}
		}
		if (Input.GetKeyUp ("up")) {
			addMoreForce = false;
			detectCollision = true;
		}
		if (Input.GetKey ("up")) {
			if (nextJump && !jumping) {
				Jump ();
				nextJump = false;
			}
			//Keep the player character on the x value
			if (transform.position.x != centerXPos)
				transform.position = new Vector3 (centerXPos, transform.position.y, transform.position.z);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		// Resets the jump if the player character collides with something tagged as floor 
		// and the jump button has been let go
		if(col.gameObject.tag.Contains ("Environment")){//  && detectCollision){
			jumping = false;
			
		}
	}
}




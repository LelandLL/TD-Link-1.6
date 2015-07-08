using UnityEngine;
using System.Collections;

public class Eraser : MonoBehaviour {

void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Application.LoadLevel ("Game Over Screen");
			return;
		}
		if (other.gameObject.transform.parent) {
			Destroy(other.gameObject.transform.parent.gameObject);
		} 
        else {
			Destroy(other.gameObject);
		}
	}
}

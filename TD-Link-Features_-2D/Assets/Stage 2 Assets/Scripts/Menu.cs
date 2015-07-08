using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string nextScene = "MainLevel";
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Application.LoadLevel(nextScene);
		}
	}

	public void RestartLevel(){
		Application.LoadLevel ("MainLevel");
}
	
	public void ReturnToTitle(){
		Application.LoadLevel ("Title");
	}
}

using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public string nextScene = "MainLevel";
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Application.LoadLevel(nextScene);
		}
	}
	
	public void RestartLevel(){
		Application.LoadLevel ("Try Again");
	}
	public void ReturnToMenu()
	{
		Application.LoadLevel("Main Menu");
	}
	public void ReturnToTitle(){
		Application.LoadLevel ("Quit the Game");
	}
}

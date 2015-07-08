using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void BeginGame()
	{
		Application.LoadLevel ("MainLevel");
	}
	public void Explanation()
	{
		Application.LoadLevel ("Explain");
	}
	public void ExitGame()
	{
		Application.LoadLevel ("Intro Cutscene");
	}
}

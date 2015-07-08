using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Text continueText;
	public Text scoreText;

	private float timeElapsed = 0f;
	private float bestTime = 0f;
	private float blinkTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private GameObject Timer;
	private SpawnObjects spawner;
	private bool beatBestTime;

	void Awake(){
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find("Spawner").GetComponent<SpawnObjects>();
		timeManager = GetComponent<TimeManager>();
	}

	void Start () {
		var floorHeight = floor.transform.localScale.y;

		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelisToUnits) / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		Time.timeScale = 0;

		continueText.text = "PRESS ANY BUTTON TO START";

		bestTime = PlayerPrefs.GetFloat ("BestTime");
	}
	
	// Update is called once per frame
	void Update () {
	if (!gameStarted && Time.timeScale == 0) {
		if (Input.anyKeyDown) {
				timeManager.ManipulateTime(1,1f);
				ResetGame ();
			}
		}
		if (!gameStarted) {
			blinkTime++;
			if (blinkTime % 40 == 0) {
				blink = !blink;
			}
			continueText.canvasRenderer.SetAlpha (blink ? 0 : 1);

			var textColor = beatBestTime ? "#FFC" : "#FFF";

			scoreText.text = "TIME: " + FormatTime (timeElapsed) + "\n<color=" +textColor+ ">BEST: " + FormatTime (bestTime)+ "</color>";
		} 
		else {
			timeElapsed += Time.deltaTime;
			scoreText.text = "TIME: " + FormatTime (timeElapsed);
		}

	}
	void OnPlayerKilled(){
		spawner.active = false;

		var playerDestroyScript = player.GetComponent<DestroyOffScreen> ();
		playerDestroyScript.DestroyCallBack -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;

		continueText.text = "PRESS ANY KEY TO TRY AGAIN";

		if (timeElapsed > bestTime) {
			bestTime = timeElapsed;
			PlayerPrefs.SetFloat("bestTime", bestTime);
			beatBestTime = true;
		}
	}

	void ResetGame(){
		spawner.active = true;

		player = GameObjectUntil.Instantiate(playerPrefab, new Vector3(0, (Screen.height/PixelPerfectCamera.pixelisToUnits)/ 2, 0));

		var playerDestroyScript = player.GetComponent<DestroyOffScreen> ();
		playerDestroyScript.DestroyCallBack += OnPlayerKilled;

		gameStarted = true;

		continueText.canvasRenderer.SetAlpha(0);

		timeElapsed = 0;
		beatBestTime = false;
	}
	string FormatTime(float value){
		TimeSpan t = TimeSpan.FromSeconds (value);

		return string.Format("{0:D2}: {1:D2}", t.Minutes, t.Seconds);
	}
}

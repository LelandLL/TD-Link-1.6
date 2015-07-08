using UnityEngine;
using System.Collections;

public class EndlessRun : MonoBehaviour {
	
	public float baseEndlessSpeed;
	public float maxEndlessSpeed;
	public float Acceleration;
	static public float globalSpeed;
	
	
	void Awake()
	{
		EndlessRun.globalSpeed = baseEndlessSpeed;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (globalSpeed < maxEndlessSpeed)
			globalSpeed += Time.deltaTime * Acceleration;
	}
}




using UnityEngine;
using System.Collections;
[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class Attack : MonoBehaviour {

	//Shooting
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

}

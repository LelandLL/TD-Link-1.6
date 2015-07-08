using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUntil {

	private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool> ();


	public static GameObject Instantiate(GameObject prefab, Vector3 pos){
		GameObject instance = null;


		var recycleScript = prefab.GetComponent<RecycleGameObject>();
		if (recycleScript != null) {
			var pool = GetObjectPool (recycleScript);
			instance = pool.NextObject (pos).gameObject;
		} else {

			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;
		}
		return instance;
	}

	public static void Destroy(GameObject gameObject){

		var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();

		if (recycleGameObject != null) {
			recycleGameObject.Shutdown ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}
	private static ObjectPool GetObjectPool(RecycleGameObject referernce){
		ObjectPool pool = null;


			if (pools.ContainsKey(referernce)) {
			pool = pools[referernce];
			}else{
				var poolContainer = new GameObject(referernce.gameObject.name + "ObjectPool");
				pool = poolContainer.AddComponent<ObjectPool>();
				pool.prefab = referernce;
				pools.Add(referernce, pool);
			}
			return pool;
		}
}

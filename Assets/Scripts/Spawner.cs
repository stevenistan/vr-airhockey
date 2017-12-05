using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject powerup;

	// Use this for initialization
	void Start () {
		float interval = Random.Range (1f, 2f);
		Invoke ("Spawn", interval);
			
	}
	
	public void Spawn () {
		if (GameObject.FindGameObjectsWithTag ("Powerup").Length == 0) {
			float z = Random.Range (-0.8f, 0.8f);
			Object.Instantiate (powerup, new Vector3 (0, 0.05f, z), Quaternion.identity);
			float interval = Random.Range (3f, 20f);
			Invoke ("Spawn", interval);
		} else {
			Invoke ("Spawn", 0.1f);

		}

	}
}

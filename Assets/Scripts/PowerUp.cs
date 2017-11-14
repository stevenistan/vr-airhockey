using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

	public float speed = 100f;
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Puck") {
			Effect (c.gameObject.GetComponent<Puck>().lastPaddle);
			gameObject.SetActive (false);
		}
	}

	public abstract void Effect (GameObject g);
}

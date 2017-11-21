using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public float speed = 100f;
	public float scale;
	public float duration;
	GameObject paddle;
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Puck") {
			Effect (c.gameObject.GetComponent<Puck>().lastPaddle);
			gameObject.SetActive (false);
		}
	}

	public void Effect(GameObject g) {
		paddle = g;
		g.transform.localScale *= scale;
		Object.Destroy (gameObject, duration);
	}

	public void OnDestroy() {
		paddle.transform.localScale /= scale;
	}
}

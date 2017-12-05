using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBoost : PowerUp {
	public float scale;
	public float duration;
	GameObject paddle;
	private bool hit = false;

	public override void Effect(GameObject g) {
		if (hit != true) {
			paddle = g;
			g.transform.localScale *= scale;
			hit = true;
			gameObject.GetComponent<Renderer> ().enabled = false;
			StartCoroutine (holdon ());
		}
	}


	IEnumerator holdon() {
		yield return new WaitForSeconds(5);
		paddle.transform.localScale /= scale;
		hit = false;
		Destroy (gameObject);

	}
}

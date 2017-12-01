using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBoost : PowerUp {
	public float scale;
	public float duration;
	GameObject paddle;

	public override void Effect(GameObject g) {
		paddle = g;
		g.transform.localScale *= scale;
		//Object.Destroy (gameObject, duration);
		g.SetActive (false);
		StartCoroutine (respawn ());
		g.SetActive (true);
		g.transform.localPosition = new Vector3 (Random.Range (-1.75f, 1.75f), 0, Random.Range (-1f, 1f));
	}

	public void OnDestroy() {
		paddle.transform.localScale /= scale;
	}

	IEnumerator respawn() {
		yield return new WaitForSeconds(duration);
		paddle.transform.localScale /= scale;
	}
}

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
		Object.Destroy (gameObject, duration);
	}

	public void OnDestroy() {
		paddle.transform.localScale /= scale;
	}
}

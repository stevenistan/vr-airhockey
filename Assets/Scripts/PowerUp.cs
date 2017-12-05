using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
	private AudioSource audioSource;
	public AudioClip powerupSound;
	public float speed = 100f;
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Puck") {
			audioSource.PlayOneShot (powerupSound);
			Effect (c.gameObject.GetComponent<Puck>().lastPaddle);
		}
	}

    public abstract void Effect(GameObject g);
}

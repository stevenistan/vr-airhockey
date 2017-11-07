using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck: MonoBehaviour {
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		StartCoroutine (resetPosition ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("down")) {
			rb.AddForce(10, 0, 0);
		}
		if (Input.GetKey ("up")) {
			rb.AddForce(-10, 0, 0);;
		}
		if (Input.GetKey ("right")) {
			rb.AddForce(0, 0, 10);;
		}
		if (Input.GetKey ("left")) {
			rb.AddForce(0, 0, -10);;
		}
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "AIGoal") {
			StartCoroutine(resetPosition ());
			print ("YOU SCORED!");
		} else if (col.gameObject.name == "PlayerGoal") {
			StartCoroutine(resetPosition ());
			print ("AI scored...");
		} else if (col.gameObject.name == "Paddle") {
			rb.AddForce (col.contacts [0].normal * 2, ForceMode.Impulse);
		} else {
			rb.AddForce (col.contacts [0].normal * 1.1f, ForceMode.Impulse);
		}
	
	}

	IEnumerator resetPosition() {
		rb.velocity = Vector3.zero;
		transform.position = new Vector3 (0, 0.3f, 0);
		yield return new WaitForSeconds(1.5f);
		rb.AddForce (new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f)) * 3, ForceMode.Impulse);
	}
}

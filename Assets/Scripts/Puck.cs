using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck: MonoBehaviour {
	Rigidbody rb;
	public GameObject lastPaddle;
	public float maxMagnitude = 5f;
	public float minMagnitude = 2f;
	public ScoreUI scoreUI;
	private AudioSource audioSource;
	public AudioClip hitSound;
	public AudioClip scoreSound;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		StartCoroutine (resetPosition ());
		audioSource = gameObject.GetComponent<AudioSource> ();
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

		if (rb.velocity.magnitude > maxMagnitude)
			rb.velocity = Vector3.Normalize (rb.velocity) * maxMagnitude;
		if (rb.velocity.magnitude < minMagnitude)
			rb.velocity = Vector3.Normalize (rb.velocity) * minMagnitude;
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "AIGoal") {
			StartCoroutine(resetPosition ());
			scoreUI.ScorePlayer ();
			audioSource.PlayOneShot (scoreSound);
		} else if (col.gameObject.name == "PlayerGoal") {
			StartCoroutine(resetPosition ());
			scoreUI.ScoreAI ();
			audioSource.PlayOneShot (scoreSound);
		} else if (col.gameObject.name == "Paddle") {
			rb.AddForce (col.contacts [0].normal * 2, ForceMode.Impulse);
			lastPaddle = col.gameObject;
			audioSource.PlayOneShot (hitSound);

		} else if (col.gameObject.name == "AI") {
			rb.AddForce (col.contacts [0].normal * 1.1f + new Vector3(1f, 0f, 1.5f), ForceMode.Impulse);
			lastPaddle = col.gameObject;
			float step = 15 * Time.deltaTime;
			audioSource.PlayOneShot (hitSound);

			//lastPaddle.transform.localPosition = Vector3.MoveTowards (lastPaddle.transform.localPosition, new Vector3 (-14.885f, 0.3249f, -0.91f), step);
		} else if (col.gameObject.tag == "MyWall") {
			rb.AddForce (col.contacts [0].normal * 1.1f, ForceMode.Impulse);
			audioSource.PlayOneShot (hitSound);

		}
	
	}

	IEnumerator resetPosition() {
		rb.velocity = Vector3.zero;
		transform.position = new Vector3 (0, 0.05f, 0);
		yield return new WaitForSeconds(1.5f);
		rb.AddForce (new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f)) * minMagnitude, ForceMode.Impulse);
	}
}

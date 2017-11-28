using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	private Rigidbody rb;

	public GameObject puck;
	private bool canTrigger = true;

	private float nextAction = 0.0f;
	private float period = 1.0f;
	private float rando = 1.0f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

	}

	// Update is called once per frame
	void Update()
	{
		if (puck.transform.localPosition.x < -8)
		{
			if (Mathf.Abs (puck.transform.localPosition.x - transform.position.x) < 0.5f) {
				float step = 50 * Time.deltaTime;
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (puck.transform.localPosition.x, transform.localPosition.y, puck.transform.localPosition.z), step);
			} else {
				float step = 40 * Time.deltaTime;
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (puck.transform.localPosition.x - 1f, transform.localPosition.y, puck.transform.localPosition.z), step);
			}
		}
		if (-7 < transform.localPosition.x)
		{
			rb.velocity = new Vector3(-0.1f, 0, 0);
		}

	}


}
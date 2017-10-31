using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody r = GetComponent<Rigidbody> ();
		if (Input.GetKey ("right")) {
			r.AddForce(10, 0, 0);
		}
		if (Input.GetKey ("left")) {
			r.AddForce(-10, 0, 0);;
		}
		if (Input.GetKey ("up")) {
			r.AddForce(0, 0, 10);;
		}
		if (Input.GetKey ("down")) {
			r.AddForce(0, 0, -10);;
		}
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "MyWall")
		{
			Destroy(col.gameObject);
		}
	}
}

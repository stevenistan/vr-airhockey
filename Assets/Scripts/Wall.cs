using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject puck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "PaddleAI") {
			other.transform.localPosition = new Vector3 (-2.29f, 0.3f, other.transform.localPosition.z); 
			other.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
		if (other.gameObject.name == "Paddle") {
			other.transform.localPosition = new Vector3 (2.31f, 0.3f, other.transform.localPosition.z); 
			other.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
	}
}

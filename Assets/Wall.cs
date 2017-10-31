using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Puck") {
			other.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			other.transform.localPosition = new Vector3 (0, 0, 0);
			if (gameObject.name == "Wall Bottom") {
				print ("The AI scored");
			} else {
				print ("You scored");
			}
		}
	}
}

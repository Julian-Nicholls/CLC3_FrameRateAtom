using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ensure a rigidbody is attached
[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

	public float attractionForce;
	Rigidbody body;

	// Use this for initialization
	//not sure why we're using awake instead of start
	void Awake () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	//fixed update is used for physics so it's not dependent on frames
	void FixedUpdate () {

		//not sure how this makes them all collide in the centre, but it does
		body.AddForce (transform.localPosition * -attractionForce);
	}
}

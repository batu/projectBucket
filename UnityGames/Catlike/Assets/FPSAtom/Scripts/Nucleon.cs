﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {


    public float attractionForce;

    Rigidbody body;

	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        body.AddForce(transform.localPosition * -attractionForce);
	}
}

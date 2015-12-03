using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    Rigidbody rb;

    public float speed = 10;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity.magnitude < 10 && Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("press accepted");
            rb.AddForce(Vector3.forward * speed * 1000);
        }

        if (Input.GetKey(KeyCode.W)){
            Debug.Log("press accepted");
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector3.right * speed);
        }

    }
}

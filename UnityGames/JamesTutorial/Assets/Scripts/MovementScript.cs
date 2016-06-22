using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public float speed = 4f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame

    void Update() {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        xMovement *= 1f;
        zMovement *= 1f;

        transform.Rotate(new Vector3(xMovement, 0, zMovement));

        if (Input.GetKey(KeyCode.Space)) GetComponent<Rigidbody>().AddForce(transform.right * speed * -1);
    }
}
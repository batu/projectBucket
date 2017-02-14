using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    Vector3 moveDirection;
    Rigidbody rb;

    public float moveSpeed = 5f;

    float moveHorizontal;
    float moveVertical;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}



    // Update is called once per frame
    void FixedUpdate () {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0) {
            Vector3 left = transform.right * moveHorizontal * moveSpeed * -1 ;
            rb.AddForce(left);
        }
        if (moveVertical != 0) {
            Vector3 right = transform.forward * moveVertical * moveSpeed * -1;
            rb.AddForce(right);
        }
    }
}

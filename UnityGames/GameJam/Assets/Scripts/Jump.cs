using UnityEngine;
using System.Collections;



public class Jump : MonoBehaviour {

    public float jumpModifier = 0.1f;
    private float jumpPower = 0;
    private float oldJumpPower;

    bool backJumped = false;


    public GameObject nextPlaneObj =null;

    private Vector3 targetDirection;

    private Vector3 currentPlane;
    public bool onGround = true;




    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
    }
	

    void jumpBack() {

        if (!backJumped) {
            backJumped = true;
            Debug.Log(oldJumpPower);
            rb.velocity = Vector3.zero;
            float distance = Vector3.Distance(currentPlane, transform.position);
            Vector3 reverseDirection = targetDirection;
            reverseDirection.Scale(new Vector3(-1, 1, -1));
            rb.AddForce(reverseDirection * oldJumpPower, ForceMode.Impulse);
        }


    }

    void jump() {

        Vector3 nextPlane = nextPlaneObj.transform.position;
        currentPlane = transform.position;
        float distance = Vector3.Distance(nextPlane, transform.position);
        targetDirection = new Vector3(nextPlane.x - transform.position.x, (nextPlane.y + distance) / 2, nextPlane.z - transform.position.z);
        Debug.Log(targetDirection);
        targetDirection.Normalize();
        currentPlane = transform.position;

        rb.AddForce(targetDirection * jumpPower, ForceMode.Impulse);
        oldJumpPower = jumpPower;
        Debug.Log(jumpPower);
        jumpPower = 0;
        backJumped = false;

    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(Application.loadedLevel);
        }


        if (Input.GetKey(KeyCode.Space) && onGround) {
            jumpPower += jumpModifier;
        }
	
        if (Input.GetKeyUp(KeyCode.Space) && onGround) {
            jump();
        }

        if(transform.position.y < currentPlane.y - 0.2f) {
            jumpBack();
        }

        
    }
}

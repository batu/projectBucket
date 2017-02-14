using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    [HideInInspector]
    public Rigidbody rb;

    

    public float speed = 50f;
    public float speedIncrease = 0.001f;
    public float sideSpeed = 75f;

    public float crashTreshold = 50f;



    public float rotationAngle = 50f;
    public float rotationSpeed = 0.1f;

    public GameObject explosion;

    camera CameraScript;
    worldBuilder worldBuilderScript;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        
        CameraScript = GameObject.Find("GameManager").GetComponent<camera>();
        worldBuilderScript = GameObject.Find("GameManager").GetComponent<worldBuilder>();
    }


    void OnCollisionEnter(Collision collision) {


        if (collision.impulse.z > crashTreshold) {


            CameraScript.enabled = false;
            worldBuilderScript.enabled = false;

            Instantiate(explosion, new Vector3(gameObject.transform.position.x,
                                    gameObject.transform.position.y,
                                    gameObject.transform.position.z), Quaternion.identity);
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void FixedUpdate() {
        speed += speedIncrease;
        sideSpeed += speedIncrease * 20;
        if (rb.velocity.magnitude < 10 && Input.GetKeyDown(KeyCode.W)) {
            rb.AddForce(Vector3.forward * speed * 100);
        }

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A)) {
            MoveSide(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D)) {
            MoveSide(Vector3.right);
        }


        rotateToDirection();

    }

    void MoveSide(Vector3 direction) {

        rb.AddForce(direction * sideSpeed);

        rotateToDirection(direction);

    }

    void rotateToDirection(Vector3 direction = default(Vector3) ) {
        float lerpTime = 1f;
        float currentLerpTime = 0f;

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
        float perc = currentLerpTime / lerpTime;
        perc = Mathf.Sin(perc * Mathf.PI * 0.5f);

        if(direction == Vector3.right) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotationAngle, 90f, 0f), perc);

        } else if (direction == Vector3.left) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-rotationAngle, 90f, 0f), perc);

        } else {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0f), perc);
        }

    }
}

using UnityEngine;
using System.Collections;

public class platformScript : MonoBehaviour {


    public GameObject platform;
    public GameObject player;

    bool firstTime = true;

    Jump jumpScript; 

	// Use this for initialization
	void Start () {
        jumpScript = player.GetComponent<Jump>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision collision) {
        if (firstTime) {
            createNewPlatform();
        }


    }

    void createNewPlatform() {


        float distance = Random.Range(20, 30);
        Vector3 newPosition = new Vector3(transform.position.x + distance,
                                          transform.position.y,
                                          transform.position.z);

        
        jumpScript.nextPlaneObj = Instantiate(platform, newPosition, Quaternion.Euler(Vector3.zero) ) as GameObject;

        firstTime = false;
    }
}

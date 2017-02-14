using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Camera mainCam;
    public GameObject player;

    public float zOffSet = -15f;
    public float yOffSet = 15f;

    Transform playerTransform;
    
	// Use this for initialization
	void Start () {
       
        playerTransform = player.transform;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        mainCam.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffSet, playerTransform.position.z + zOffSet);

    }
}

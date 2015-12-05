using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    worldBuilder worldBuilderScript;
    public Camera mainCam;
    public float zOffSet = -15f;
    public float yOffSet = 15f;

    Transform playerTransform;
    
	// Use this for initialization
	void Start () {
        worldBuilderScript = GetComponent<worldBuilder>();
        playerTransform = worldBuilderScript.player.transform;
        mainCam.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffSet, playerTransform.position.z + zOffSet);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        mainCam.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffSet, playerTransform.position.z + zOffSet);

    }
}

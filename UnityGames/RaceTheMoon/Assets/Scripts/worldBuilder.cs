using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class worldBuilder : MonoBehaviour {


    movement movementScript;

    public GameObject worldTile;
    public GameObject playerPrefab;

    [HideInInspector]
    public GameObject player;

    Rigidbody playerRB;

    public GameObject road;

    bool inFirstTen = true;

    Vector3 playerStartPos = new Vector3 (302.71f, -249.31f, 290.0697f);

    float worldTileX = 300.8538f;
    float worldTileY = -251.6736f;
    int tileCounter = 2;

    float lastKnownPlayerPosition;
	// Use this for initialization
	void Awake () {
        setup();


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        addRoadTile();
    }


    void setup() {
        player = Instantiate(playerPrefab, playerStartPos, Quaternion.Euler(0f, 90f, 0f)) as GameObject;
        playerRB = player.GetComponent<Rigidbody>();
        lastKnownPlayerPosition = player.transform.position.z;
        for (int x = 0; x < 10; x++) {
            GameObject roadTile = Instantiate(worldTile, new Vector3(worldTileX, worldTileY, tileCounter * 182.86f), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
            roadTile.transform.parent = road.transform;
            tileCounter++;
            lastKnownPlayerPosition = player.transform.position.z;
        }
    }

    void addRoadTile() {

        if (lastKnownPlayerPosition + 182.86f < player.transform.position.z) {
            GameObject roadTile = Instantiate(worldTile, new Vector3(worldTileX, worldTileY, tileCounter * 182.86f), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
            roadTile.transform.parent = road.transform;
            tileCounter++;
            lastKnownPlayerPosition = player.transform.position.z;
            Debug.Log(playerRB.velocity.magnitude);
        }

    }


}




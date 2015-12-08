using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class worldBuilder : MonoBehaviour {


    movement movementScript;

    public GameObject worldTile;
    public GameObject playerPrefab;

    [HideInInspector]
    public GameObject player;
    public GameObject roadBase;
    public GameObject obstacle;

    Rigidbody playerRB;

    public GameObject road;

    bool inFirstTen = true;

    Vector3 playerStartPos = new Vector3 (302.71f, -249.31f, 290.0697f);

    float worldTileX = 300.8538f;
    float worldTileY = -251.6736f;

    float worldTileXLen = 96;
    float worldTileZLen = 86;

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

        addEmptyRoadTile();
        for (int x = 5; x < 50; x++) {
            createRandomRoadTile();
            tileCounter++;
        }
    }

    void addRoadTile() {
        if (lastKnownPlayerPosition + 182.86f < player.transform.position.z) {
            createRandomRoadTile();
            tileCounter++;
            lastKnownPlayerPosition = player.transform.position.z;
            Debug.Log(playerRB.velocity.magnitude);
        }
    }



void addEmptyRoadTile() {
        for (int x = 0; x < 5; x++) {
            GameObject roadTile = Instantiate(roadBase, new Vector3(worldTileX, worldTileY, tileCounter * 182.86f), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
            roadTile.transform.parent = road.transform;
            tileCounter++;
            lastKnownPlayerPosition = player.transform.position.z;
        }
    }





    void createRandomRoadTile() {
        GameObject baseTile = Instantiate(roadBase, new Vector3(worldTileX, worldTileY, tileCounter * 182.86f), Quaternion.Euler(0f, 90f, 0f)) as GameObject;

        float randX = Random.Range(worldTileX - worldTileXLen / 2, worldTileX + worldTileXLen / 2);
        float randZ = Random.Range(-worldTileZLen / 2, worldTileZLen / 2);

        GameObject obstacleInstance = Instantiate(obstacle, new Vector3(randX, worldTileY, (tileCounter * 182.86f) + randZ), Quaternion.Euler(0f, 90f, 0f)) as GameObject;

        if (1 == Random.Range(0, 1)) {
            obstacleInstance = Instantiate(obstacle, new Vector3(randX, worldTileY, (tileCounter * 182.86f) + randZ), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
        }
        baseTile.transform.parent = road.transform;
        obstacleInstance.transform.parent = baseTile.transform;

    }


}




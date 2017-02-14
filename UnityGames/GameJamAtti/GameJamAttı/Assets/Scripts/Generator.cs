using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject player;
    int yOffSet = -500;

    Transform playerTransform;

    public GameObject rainclouds;
    public GameObject obstacles;

    public int sphereSize = 50;


    // Use this for initialization
    void Start() {
        StartCoroutine(spawnShit());
        playerTransform = player.transform;
    }

    IEnumerator spawnShit() {
        while (true) {
            if (Random.Range(0f,1f) < 0.9f) {
                Vector3 randomSphere = Random.insideUnitSphere * sphereSize;
                Instantiate(obstacles, transform.position + randomSphere, Quaternion.identity);
            } else {
                Vector3 randomSphere = Random.insideUnitSphere * sphereSize;
                Instantiate(rainclouds, transform.position + randomSphere, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.00001f);
        }
        
    }


    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffSet, playerTransform.position.z);
    }
}

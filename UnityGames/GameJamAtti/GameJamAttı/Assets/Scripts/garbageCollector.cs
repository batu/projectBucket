using UnityEngine;
using System.Collections;

public class garbageCollector : MonoBehaviour {

    public GameObject player;

    public float yOffSet = 50f;

    Transform playerTransform;

    // Use this for initialization
    void Start() {

        playerTransform = player.transform;

    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffSet, playerTransform.position.z);
    }

    void OnTriggerEnter(Collider col) {

        Destroy(col.gameObject);

    }
}

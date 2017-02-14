using UnityEngine;
using System.Collections;

public class smaller : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Player") {
            Debug.Log("I COLLIDED!");
            if(col.transform.localScale.x < 0.1) {
                Destroy(col.gameObject);
            }
            col.transform.localScale = new Vector3(col.transform.localScale.x * 0.5f,
                                                    col.transform.localScale.y * 0.5f,
                                                    col.transform.localScale.z * 0.5f);
        }

    }
}

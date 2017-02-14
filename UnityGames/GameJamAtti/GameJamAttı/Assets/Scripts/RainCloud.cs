using UnityEngine;
using System.Collections;

public class RainCloud : MonoBehaviour {


    float growthSize = 1.5f;
	// Use this for initialization
	void Start () {
	
	}


    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Player") {
            Debug.Log("I COLLIDED!");
            col.transform.localScale = new Vector3( col.transform.localScale.x * growthSize,
                                                    col.transform.localScale.y * growthSize, 
                                                    col.transform.localScale.z * growthSize);
        }
    }

}

using UnityEngine;
using System.Collections;

public class crash : MonoBehaviour {



    public GameObject explosion;

    void Start() {
       // rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col) {

        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag == "Player") {
            Debug.Log("Collision WITH DOOM detected.");
            Instantiate(explosion, new Vector3(gameObject.transform.position.x,
                                                gameObject.transform.position.y,
                                                gameObject.transform.position.z), Quaternion.identity);
           // Destroy(col.gameObject);
        }
       
    }
}

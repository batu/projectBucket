using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {



    void OnCollisionEnter(Collision collision) {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        Destroy(gameObject);
        health.TakeDamage(10);
    }
}

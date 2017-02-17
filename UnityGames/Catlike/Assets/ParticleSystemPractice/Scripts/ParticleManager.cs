using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    ParticleSystem myParticleSystem;

    GameObject fish;
    public float swingRate = 1f;
    public float swingAngle = 10f;

    public float moveRate = 0.1f;
    public float moveDepth = 2f;

    float y_anchor;
    // Use this for initialization
    void Start () {
        myParticleSystem = GameObject.FindGameObjectWithTag("Particles").GetComponent<ParticleSystem>();
        fish = GameObject.Find("Fish");
        y_anchor = fish.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            myParticleSystem.Play();
        }
        fish.transform.localRotation = Quaternion.Euler(0, 90 + (Mathf.Sin(Time.time * swingRate) * swingAngle), 0);
        fish.transform.position = new Vector3(fish.transform.position.x, y_anchor + (Mathf.Sin(Time.time * moveRate) * moveDepth), fish.transform.position.z);

    }



}

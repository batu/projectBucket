using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasters : MonoBehaviour {

    public GameObject[] raycasters;

    NeedleGenerator _NeedleGenerator;
    // Use this for initialization
    void Start () {
        _NeedleGenerator = GetComponent<NeedleGenerator>();

        foreach (GameObject raycaster in raycasters) { 
            Debug.DrawRay(raycaster.transform.position, raycaster.transform.forward * 10, Color.yellow);
        }
        
    }
	
    void CalculatePI() {
        int collisions = 0;
        foreach (GameObject raycaster in raycasters) {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(raycaster.transform.position, raycaster.transform.forward, 100f);
            foreach(RaycastHit hit in hits) {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                collisions++;
            }
        }
    }


	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            CalculatePI();
        }	
	}
}

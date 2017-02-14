using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour {
    public bool remover;

    int killCount = 0;
    NeedleGenerator _NeedleGenerator;
    // Use this for initialization
    void Start () {
        _NeedleGenerator = GameObject.FindGameObjectWithTag("Generator").GetComponent<NeedleGenerator>();
    }
	
    void OnTriggerEnter(Collider collider) {
        if(remover) _NeedleGenerator.needles.Remove(collider.gameObject);
        Destroy(collider.gameObject);
        print(++killCount);
    }
}

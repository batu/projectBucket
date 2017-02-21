using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {
    int x;
    // Use this for initialization
    void Start () {
		for(x = 0; x < 255; x++) {
            //print(x);
        }
        for (int counter = 255; counter >= 0; counter -= 5) {
            print("I am decreasing by 5");
        }

        for (int counter = 255; counter >= 0; counter--) {
            print("I am decreasing by 1");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

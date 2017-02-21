using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {


	// Use this for initialization
	void Start () {

        StartCoroutine(twohundredsteps());
    }


    IEnumerator threeSteps() {
        for(int x = 0; x < 4; x++) {

            Color digitalWrite = new Color(0, 0, 75 * x);

            GetComponent<Renderer>().material.color = digitalWrite;
            print("I am here");
            yield return new WaitForSeconds(2);
        }
        


    }

    IEnumerator twohundredsteps() {
        for (float x = 0f; x < 255; x++) {

            Color digitalWrite = new Color(0, 0, x/100);

            GetComponent<Renderer>().material.color = digitalWrite;
            yield return new WaitForSeconds(.05f);
        }
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.A)) {
            StartCoroutine(threeSteps());
        }

        if (Input.GetKey(KeyCode.B)) {

        }
    }
}

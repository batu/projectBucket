using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineCaster : MonoBehaviour {

    public bool doubleLength = true;
    public GameObject[] linecasters;
    float collisions = 0;
    NeedleGenerator _NeedleGenerator;

    public GameObject text;

    // Use this for initialization
    void Start() {
        _NeedleGenerator = GameObject.FindGameObjectWithTag("Generator").GetComponent<NeedleGenerator>();
        }

    void ScanForItems(BoxCollider item) {
        Vector3 center = item.transform.position + item.center;
        Collider[] allOverlappingColliders = Physics.OverlapBox(center, new Vector3(item.gameObject.transform.lossyScale.x / 2f,
                                                                                    item.gameObject.transform.lossyScale.y / 2f,
                                                                                    item.gameObject.transform.lossyScale.z / 2f));
        foreach(Collider needleCol in allOverlappingColliders) {
            if (needleCol.gameObject.tag == "Ground" || needleCol.gameObject.tag == "Counted") continue;
            needleCol.gameObject.GetComponent<Renderer>().material.color = Color.green;
            needleCol.gameObject.tag = "Counted";
           collisions++;
        }
    }


    void CalculatePI() {

        foreach( GameObject line in linecasters) {
            ScanForItems(line.GetComponent<BoxCollider>());
        }
        print(collisions);
        print(_NeedleGenerator.needles.Count);

        float pi = _NeedleGenerator.needles.Count  / collisions;
        pi = !doubleLength ? pi * 2 : pi;
        Debug.Log("PI IS: " + pi.ToString());
        text.SetActive(true);
        text.GetComponent<TextMesh>().text = "PI IS: " + pi.ToString();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            CalculatePI();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }
}

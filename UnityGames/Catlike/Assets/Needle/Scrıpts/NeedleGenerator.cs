using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerator : MonoBehaviour {

    public int maxNeedleCount = 100;
    public float force = 1f;
    int needleCount = 0;
    public GameObject needle;

    [HideInInspector]
    public List<GameObject> needles;
    // Use this for initialization
    void Start () {
        StartCoroutine(generate());
	}

    

    IEnumerator generate() {
        
        while (++needleCount < maxNeedleCount) {
            GameObject thisNeedle = Instantiate(needle, transform.position, Random.rotationUniform, transform);
            needles.Add(thisNeedle);
            thisNeedle.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * force, ForceMode.Impulse );
            yield return null;
        }
    }
	
}

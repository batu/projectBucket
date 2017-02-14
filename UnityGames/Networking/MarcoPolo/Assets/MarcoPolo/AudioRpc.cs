using UnityEngine;

public class AudioRpc : MonoBehaviour {

    public AudioClip marco;
    public AudioClip polo;

    [PunRPC]
    void Marco() {
        Debug.Log("Marco");

        GetComponent<AudioSource>().clip = marco;
        GetComponent<AudioSource>().Play();
    }

    [PunRPC]
    void Polo() {
        Debug.Log("Polo");

        GetComponent<AudioSource>().clip = polo;
        GetComponent<AudioSource>().Play();
    }
}
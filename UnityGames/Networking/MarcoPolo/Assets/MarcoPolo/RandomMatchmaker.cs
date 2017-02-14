using UnityEngine;
using Photon;
using System.Collections;

public class RandomMatchmaker : Photon.PunBehaviour {
    private PhotonView myPhotonView;


    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
        // This is important for debugging
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
    }

    void OnGUI() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        if (PhotonNetwork.connectionStateDetailed == PeerState.Joined) {
            if (GUILayout.Button("Marco!")) {
                myPhotonView.GetComponent<PhotonView>().RPC("Marco", PhotonTargets.All);
                
            }
            if (GUILayout.Button("Polo!")) {
                myPhotonView.GetComponent<PhotonView>().RPC("Polo", PhotonTargets.All);
            }
        }
    }

    public override void OnJoinedLobby() {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom() {
        GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
        monster.GetComponent<myThirdPersonController>().isControllable = true;
        myPhotonView = monster.GetComponent<PhotonView>();
    }

    void OnPhotonRandomJoinFailed() {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }


}

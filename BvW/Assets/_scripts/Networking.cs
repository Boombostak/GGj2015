using UnityEngine;
using System.Collections;

public class Networking : MonoBehaviour {

    public int player_number;
    public MouseControl mc;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
        mc = gameObject.GetComponent<MouseControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        if (player_number!=1)
        {
            player_number = 2;
            
            mc.SetPlayerNumber();
        }
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
        player_number = 1;
        mc.SetPlayerNumber();
    }
}

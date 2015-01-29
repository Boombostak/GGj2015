using UnityEngine;
using System.Collections;

public class Networking : MonoBehaviour {

    private static Networking _instance;
    public static Networking instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Networking>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
        
    }
    
    public int player_number;
    public MouseControl mc;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }

        
        mc = gameObject.GetComponent<MouseControl>();
    }

	// Use this for initialization
	void Start () {
        
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
        /*if (player_number!=1)
        {
            
            mc.SetPlayerNumber();
        }*/
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
        PhotonNetwork.maxConnections = 2;
    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            player_number = 1;
        }
        else
        {
            player_number = 2;
        }
        mc.SetPlayerNumber();
    }

    public void GUIstart()
    {
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public void GUILaunch()
    {
        if (PhotonNetwork.playerList.Length == 2)
        {
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            Debug.Log("Current players:"+PhotonNetwork.playerList.Length);
        }
    }
}

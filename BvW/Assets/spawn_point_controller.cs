using UnityEngine;
using System.Collections;

public class spawn_point_controller : MonoBehaviour {

    public PhotonPlayer photon_player;
    public int player_number;
    public int intended_player_number;
    public int unit_count;
    public int unit_limit;
    public float respawn_time = 1;
    public float count_up;
    public GameObject network_controller;

    
    
    // Use this for initialization
	void Start () {

        network_controller = FindObjectOfType<Networking>().gameObject;
        
        count_up = respawn_time - 1;
	}
	
	// Update is called once per frame
	void Update () {

        player_number = network_controller.GetComponent<Networking>().player_number;

        if (player_number == 1)
	{
        unit_count = GameObject.FindGameObjectsWithTag("unit1").Length;
	}
        if (player_number == 2)
        {
            unit_count = GameObject.FindGameObjectsWithTag("unit2").Length;
        }
        
        count_up = count_up + Time.deltaTime;
        
        //respawners
        
        if ((count_up >= respawn_time) && (unit_count < unit_limit) && (player_number == 1) && (intended_player_number == 1))
        {
            PhotonNetwork.Instantiate("p1_unit", this.transform.position, (Quaternion.Euler(0, 0, 0)), 0); //group???
            count_up = 0;
        }
        
        if ((count_up >= respawn_time) && (unit_count < unit_limit) && (player_number == 2) && (intended_player_number ==2))
        {
            PhotonNetwork.Instantiate("p2_unit", this.transform.position, (Quaternion.Euler(0, 0, 0)), 0); //group???
            count_up = 0;
        }

	}
}

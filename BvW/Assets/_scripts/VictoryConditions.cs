using UnityEngine;
using System.Collections;

public class VictoryConditions : MonoBehaviour {

    public float safe_time = 10;
    public int white_units;
    public int black_units;
    public GameObject white_spawn;
    public GameObject black_spawn;
    public GameObject network_controller;
    public GameObject wvp;
    public GameObject bvp;
    public GameObject whitevic;
    public GameObject blackvic;
    
    // Use this for initialization
	void Start () {

        wvp = GameObject.Find("w_v_parent");
        bvp = GameObject.Find("b_v_parent");
        
        wvp.SetActive(false);
        bvp.SetActive(false);

        
        if (GameObject.Find("1spawn")!=null)
        {
            white_spawn = GameObject.Find("1spawn");
            Debug.Log(white_spawn + "is your white spawn point!");
        }
        else
        {
            Debug.Log("No whitespawn assigned.");
        }
        
        if (GameObject.Find("2spawn") != null)
        {
            black_spawn = GameObject.Find("2spawn");
            Debug.Log(black_spawn + "is your black spawn point!");
        }
        else
        {
            Debug.Log("No blackspawn assigned.");
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {

        white_units = GameObject.FindGameObjectsWithTag("unit1").Length;
        Debug.Log(white_units);
        black_units = GameObject.FindGameObjectsWithTag("unit2").Length;
        Debug.Log(black_units);

        if ((white_units <= 0) && (Time.time > safe_time))
        {
            BlackVictory();
        }

        if ((black_units <= 0) && (Time.time > safe_time))
        {
            WhiteVictory();
        }
	
	}

    public void WhiteVictory()
    {
        Debug.Log("White Victory!");
        //network_controller = FindObjectOfType<Networking>().gameObject;
        //victorymessage = GameObject.Find("whitevic");
        wvp.SetActive(true);
        //victorymessage.SetActive(true);
    }

    public void BlackVictory()
    {
        Debug.Log("Black Victory!");
        //network_controller = FindObjectOfType<Networking>().gameObject;
        //victorymessage = GameObject.Find("blackvic");
        bvp.SetActive(true); 
        //victorymessage.SetActive(true);
    }

    public void AdvanceLevel()
    {
        if (Application.loadedLevel==3)
        {
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            PhotonNetwork.LoadLevel(Application.loadedLevel + 1);
        }
        
    }


}

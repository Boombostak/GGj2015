using UnityEngine;
using System.Collections;

public class VictoryConditions : MonoBehaviour {

    public float safe_time = 10;
    public int white_units;
    public int black_units;
    public GameObject white_spawn;
    public GameObject black_spawn;
    public GameObject network_controller;
    public GameObject victorymessage;
    public GameObject whitevic;
    public GameObject blackvic;
    
    // Use this for initialization
	void Start () {

        
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
        whitevic.SetActive(true);
        //victorymessage.SetActive(true);
    }

    public void BlackVictory()
    {
        Debug.Log("Black Victory!");
        //network_controller = FindObjectOfType<Networking>().gameObject;
        //victorymessage = GameObject.Find("blackvic");
        blackvic.SetActive(true); 
        //victorymessage.SetActive(true);
    }

    public void AdvanceLevel()
    {
        PhotonNetwork.LoadLevel(Application.loadedLevel + 1);
    }


}

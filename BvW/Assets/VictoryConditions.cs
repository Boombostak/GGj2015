using UnityEngine;
using System.Collections;

public class VictoryConditions : MonoBehaviour {

    public float safe_time = 10;
    public int white_units;
    public int black_units;
    public GameObject white_spawn;
    public GameObject black_spawn;
    
    // Use this for initialization
	void Start () {
        white_spawn = GameObject.Find("1spawn");
        black_spawn = GameObject.Find("2spawn");
	}
	
	// Update is called once per frame
	void Update () {

        white_units = white_spawn.GetComponent<spawn_point_controller>().white_count;
        black_units = black_spawn.GetComponent<spawn_point_controller>().black_count;

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
    }

    public void BlackVictory()
    {
        Debug.Log("Black Victory!");
    }
}

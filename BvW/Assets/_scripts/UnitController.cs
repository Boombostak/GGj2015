using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    public float movespeed = 1;
    public float firerate = 1;
    public bool canmove = false;
    public bool canshoot = false;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
	}

    public void Move()
    {
        if(canmove==true)
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
        
    }

    public void Shoot()
    {
        canshoot = true;
    }

    public void Stop()
    {
        canmove = false;
        canshoot = false;
    }
}

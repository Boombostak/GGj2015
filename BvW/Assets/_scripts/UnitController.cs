using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    public float movespeed = 1f;
    public float firerate = 1f;
    public bool canmove = false;
    public bool canshoot = false;
    public GameObject bullet;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        //Shoot();

	}

    public void Move()
    {
        
        if(canmove==true)
        {
            CancelInvoke("SpawnBullet");
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
        
    }

    public void Shoot()
    {
        
        if (canshoot==true)
        {
            CancelInvoke("SpawnBullet");
            InvokeRepeating("SpawnBullet", firerate, firerate);
            
        }
    }

    public void Stop()
    {
        canmove = false;
        canshoot = false;
        CancelInvoke("SpawnBullet");
    }

    public void SpawnBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}

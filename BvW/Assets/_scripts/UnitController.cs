using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    public float movespeed = 1f;
    public float firerate = 1f;
    public bool canmove = false;
    public bool canshoot = false;
    public GameObject bullet;
    public Vector3 bullet_spawn_vector;
    public int belongs_to_player;
    
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
            bullet_spawn_vector = (this.transform.GetChild(0).transform.position);
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
        PhotonNetwork.Instantiate("bullet", bullet_spawn_vector, transform.rotation, 0);
        //Instantiate(bullet, bullet_spawn_vector, transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {

            Debug.Log("hit a wall");
            this.Stop();
        }

        if (other.tag == "unit1")
        {
            this.Stop();
        }

        if (other.tag == "unit2")
        {
            this.Stop();
        }

        if (other.tag == "deadly")
        {
            Destroy(this.gameObject);
        }
    }
}

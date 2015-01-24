using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float speed;
    public float countup = 0;
    public float lifespan = 3;
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        countup = countup + Time.deltaTime;
        if (countup >= lifespan)
        {
            Destroy(this.gameObject);
        }
	}

   
        
    
   
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "unit")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        Destroy(this.gameObject);
    }
}

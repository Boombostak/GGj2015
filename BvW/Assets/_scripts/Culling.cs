using UnityEngine;
using System.Collections;

public class Culling : MonoBehaviour {

    private GameObject instance;
    public float time_til_cull = 1;
    public float countup = 0;
    // Use this for initialization
	void Start () {
        instance = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        countup = countup + Time.deltaTime;
        if (countup>=time_til_cull)
        {
            Destroy(instance);
        }
	}
}

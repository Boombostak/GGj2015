using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

    RaycastHit hit;
    public float raycastlength = 500;
    public bool attackmode = false;
    public bool movemode = false;
    public GameObject movecursor;
    public GameObject attackcursor;
    public GameObject stopcursor;
    public GameObject selected_unit;
    public UnitController uc;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycastlength))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Terrain")
            {
                if (Input.GetMouseButtonDown(0) && (movemode==true) && (selected_unit!=null))
                {
                    GameObject movetarget = Instantiate(movecursor, hit.point, Quaternion.identity) as GameObject;
                    selected_unit.transform.LookAt(movetarget.transform);
                    uc.canshoot = false;
                    uc.canmove = true;
                }

                if (Input.GetMouseButtonDown(0) && (attackmode==true) && (selected_unit!=null))
                {
                    GameObject movetarget = Instantiate(attackcursor, hit.point, Quaternion.identity) as GameObject;
                    selected_unit.transform.LookAt(movetarget.transform);
                    uc.canmove = false;
                    uc.canshoot = true;
                    uc.Shoot();
                }
            }

            if ((hit.collider.tag == "unit") && (movemode ==false) && (attackmode==false))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selected_unit = hit.collider.gameObject.transform.parent.gameObject;
                    uc = selected_unit.GetComponent<UnitController>();
                }
                
            }
        }

        if (Input.GetButtonDown("move"))
        {
            attackmode = false;
            movemode = true;
        }

        if (Input.GetButtonDown("attack"))
        {
            movemode = false;
            attackmode = true;
        }

        if (Input.GetButtonDown("stop"))
        {
            movemode = false;
            attackmode = false;
            uc.Stop();
        }
        Debug.DrawRay(ray.origin, ray.direction * raycastlength, Color.yellow);
	
    }

}

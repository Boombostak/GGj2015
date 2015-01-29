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
    public Material su_original_mat;
    public Material su_temporary_mat_white;
    public Material su_temporary_mat_black;
    public UnitController uc;
    public int belongs_to_player;
    public int player_no;
    public GameObject network_controller;

    private static MouseControl _instance;
    public static MouseControl instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MouseControl>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }


    }
    
    // Use this for initialization
	void Start () {

        network_controller = FindObjectOfType<Networking>().gameObject;
        

	}
	
	// Update is called once per frame
	void Update () {

        belongs_to_player = network_controller.GetComponent<Networking>().player_number;

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
                    movemode = false;
                }

                if (Input.GetMouseButtonDown(0) && (attackmode==true) && (selected_unit!=null))
                {
                    GameObject movetarget = Instantiate(attackcursor, hit.point, Quaternion.identity) as GameObject;
                    selected_unit.transform.LookAt(movetarget.transform);
                    uc.canmove = false;
                    uc.canshoot = true;
                    uc.Shoot();
                    attackmode = false;
                }
            }

            //selection material change
            
            if ((hit.collider.tag == ("unit1") && (movemode ==false) && (attackmode==false) && (player_no == 1)))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (selected_unit!=null)
                    {
                        selected_unit.transform.GetChild(1).renderer.material = su_original_mat;
                    }
                    
                    
                    selected_unit = hit.collider.gameObject.transform.parent.gameObject;

                    if (su_original_mat!=selected_unit.transform.GetChild(1).renderer.material)
                    {
                        su_original_mat = selected_unit.transform.GetChild(1).renderer.material;
                    }
                    
                    
                    selected_unit.transform.GetChild(1).renderer.material = su_temporary_mat_white;
                    uc = selected_unit.GetComponent<UnitController>();
                }
                
            }

            if ((hit.collider.tag == ("unit2") && (movemode == false) && (attackmode == false) && (player_no == 2)))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (selected_unit != null)
                    {
                        selected_unit.transform.GetChild(1).renderer.material = su_original_mat;
                    }


                    selected_unit = hit.collider.gameObject.transform.parent.gameObject;

                    if (su_original_mat != selected_unit.transform.GetChild(1).renderer.material)
                    {
                        su_original_mat = selected_unit.transform.GetChild(1).renderer.material;
                    }


                    selected_unit.transform.GetChild(1).renderer.material = su_temporary_mat_black;
                    uc = selected_unit.GetComponent<UnitController>();
                }

            }

            //shoot through enemy pawns to hit terrain? This needs work.
            /*
            if ((hit.collider.tag == ("unit1") && (movemode == false) && (attackmode == false) && (player_no == 1)))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selected_unit = hit.collider.gameObject.transform.parent.gameObject;
                    uc = selected_unit.GetComponent<UnitController>();
                }

            }

            if ((hit.collider.tag == ("unit1") && (movemode == false) && (attackmode == false) && (player_no == 1)))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selected_unit = hit.collider.gameObject.transform.parent.gameObject;
                    uc = selected_unit.GetComponent<UnitController>();
                }

            }*/
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

    public void SetPlayerNumber()
    {
        player_no = gameObject.GetComponent<Networking>().player_number;
    }

    public void GUIMoveMode()
    {
        attackmode = false;
        movemode = true;
    }

    public void GUIAttackMode()
    {
        movemode = false;
        attackmode = true;
    }

    public void GUIStop()
    {
        movemode = false;
        attackmode = false;
        uc.Stop();
    }

}

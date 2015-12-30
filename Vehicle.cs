using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {


    public float gas; 
	bool inVehicle = false;
	float Vspeed = 5f; 



	public GameObject Veh; 
	//public GameObject player;
	public SpriteRenderer spriterend;
	public PolygonCollider2D coll; 
	public GameObject Hide; 
	public GameObject CameraCha; 
	public Sprite Ridding;
    public Sprite Empty;

    private Projectile projectile; 


    bool isOn;
    bool runGas;

    public GUISkin skin;

    private Inventory inventory;

    private SinglePlayerScript player;
    private FollowSingleP camera;

    private PlayerStats playStat; 

    void Start()
    {
        if (Application.loadedLevel == 1)
        {
            gas = 50;
            projectile = GameObject.Find("Hands").GetComponent<Projectile>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<SinglePlayerScript>();
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowSingleP>();
            playStat = player.GetComponent<PlayerStats>();
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }
    }
    public void multiPLayerFind()
    {
        if (Application.loadedLevel == 2) { 
        gas = 50;
        projectile = GameObject.Find("Hands").GetComponent<Projectile>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SinglePlayerScript>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowSingleP>();
        playStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); 
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            }
    }
    void Update()
    {
        if (isOn)
        {
            playStat.StopRun(false);
            inventory.Ridding(false); 
        }
        else
        {
            playStat.StopRun(true);
            inventory.Ridding(true); 
        }


        if (gas >= 100)
        {
            gas = 100; 
        }
        

        if (inVehicle == true & Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            projectile.Show(); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOn = false;
            projectile.Show(); 
        }

        if (isOn == true)
        {
            Gas();

            // Ridding in vehicle
            GetComponent<Rigidbody2D>().isKinematic = false;

            //////////////////////
            spriterend.sprite = Ridding;
            //Hide.SendMessage("Hide");
            //CameraCha.SendMessage("Veh");

            camera.Veh();
            player.Hide();

            isOn = true; // is on the vehicle 

            if (runGas)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector2.up * Vspeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(-1 * Vector2.up * (Vspeed / 2) * Time.deltaTime);
                }
                else
                {
                    //rigidbody2D.velocity = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(-1 * Vector3.forward * 3);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.forward * 3);

                }
            }
        }



        if (isOn == false)
        {
            // rigidbody2D.isKinematic = false; 


            spriterend.sprite = Empty;
            //Hide.SendMessage("Show");
            //CameraCha.SendMessage("Her");
            camera.Her();
            player.Show();
            isOn = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    public void AddGas(int addedGas)
    {
        print("add gas");
        gas = gas + addedGas; 
    }

    private void Gas()
    {
        gas = gas - .01f;

        if (gas >= 0)
        {
            runGas = true; 
        }

        if (gas <= 0)
        {
            gas = 0; 
            runGas = false; 
        }
    }

    void OnGUI()
    {
        GUI.skin = skin; 
        if (isOn)
        {

            // Skin color green
            GUI.Box(new Rect(Screen.width / 2 - 215, Screen.height - 50, gas, 30), "<color=#ffffff>" + "Gas" + "</color>", skin.GetStyle("GasSkin"));

            if(gas <= 0)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 150f, 30f), "<color=#FF0000>" + "GAS EMPTY" + "</color>",skin.GetStyle("Tooltip")); 
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inVehicle = true;
            coll.enabled = true;
        }
    }

	void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Player")
        {
            inVehicle = true;
            coll.enabled = true;
        }
        

	}


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inVehicle = false;
            coll.enabled = true;
        }
    }
}

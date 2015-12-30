using UnityEngine;
using System.Collections;

public class PlayerStats: MonoBehaviour{

     public float playerHealth;
     public float playerHunger;
     public float playerThirst;
     public float playerStamina;

     bool run;  

     public GUISkin skin;
     private SinglePlayerScript singlePlayer;

     float hungerSpeed = .005f;
     float thirstspeed = .005f;
	// Use this for initialization
	void Start () {
        Setup();
        run = true; 
        singlePlayer = GetComponent<SinglePlayerScript>(); 
        
	}
    public void Setup()
    {
        playerHealth = 100;
        playerHunger = 100;
        playerThirst = 100;
        playerStamina = 100;



    }


	// Update is called once per frame
	void Update () 
    {
       


        MaxAndMin();
        Whither(); 
	}
    public void StopRun(bool sRun)
    {
        run = sRun; 
    }
    public void Stamina()
    {
        // if run bool is false, stop leftShift for working 
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (run)
            {
                playerStamina = playerStamina - .5f;
            }
        }
        else
        {
            playerStamina = playerStamina + .05f; 
        }
    }

    private void Whither()
    {
        playerThirst = playerThirst - thirstspeed;
        playerHunger = playerHunger - hungerSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (run)
            {
                playerThirst = playerThirst - 0.005f;
            }
        }
    }

    private void MaxAndMin()
    {
        
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        if (playerHunger > 100)
        {
            playerHunger = 100; 
        }
        if (playerThirst > 100)
        {
            playerThirst = 100; 
        }
        if (playerStamina > 100)
        {
            playerStamina = 100; 
        }
        if (playerHealth < 0)
        {
            playerHealth = 0;
            Application.LoadLevel(0); 
        }
        if (playerHunger < 0)
        {
            playerHunger = 0;
            IncreaseHealth(-.5f); 
        }
        if (playerThirst < 0)
        {
            playerThirst = 0;
            IncreaseHealth(-.5f); 
        }


        if (playerStamina < 0)
        {
            playerStamina = 0;
            singlePlayer.RunBool(false); 
        }
        else
        {
            singlePlayer.RunBool(true); 
        }

        if (playerHunger > 90 && playerThirst > 90)
        {
            IncreaseHealth(.01f);
        }

         
    }
 

    public void IncreaseHealth(float incre)
    {
        playerHealth = playerHealth + incre;

    }
    public void IncreaseHunger(int incre)
    {
        playerHunger = playerHunger + incre;

    }
    public void IncreaseThirst(int incre)
    {
        Debug.Log(playerThirst);
        playerThirst = playerThirst + incre;

    }
    public void IncreaseStamina(int incre)
    {
        playerStamina = playerStamina + incre;

    }


    void OnGUI()
    {
        GUI.skin = skin; 

       // GUI.Box(new Rect(Screen.width / 30,  Screen.height / 2 + 250, playerThirst, 30), "<color=#ffffff>" + "Water" + "</color>", skin.GetStyle("WaterSkin"));
       // GUI.Box(new Rect(Screen.width / 30, Screen.height / 2 + 200, playerHunger, 30), "<color=#ffffff>" + "Hunger" + "</color>", skin.GetStyle("HungerSkin"));
       // GUI.Box(new Rect(Screen.width / 30, Screen.height / 2 + 100, playerHealth, 30), "<color=#ffffff>" +"Health" + "</color>", skin.GetStyle("HealthSkin"));
       // GUI.Box(new Rect(Screen.width / 30, Screen.height / 2 + 150, playerStamina, 30), "<color=#ffffff>" + "Stamina" + "</color>", skin.GetStyle("StaminaSkin"));

        // New Boxes
        GUI.Box(new Rect(Screen.width /2 + 110, Screen.height - 50, playerThirst, 30),"<color=#ffffff>" + "Water" + "</color>", skin.GetStyle("WaterSkin"));
        GUI.Box(new Rect(Screen.width /2 - 110 , Screen.height - 50, playerHunger, 30), "<color=#ffffff>" + "Hunger" + "</color>", skin.GetStyle("HungerSkin")); 
        GUI.Box(new Rect(Screen.width /2 + 215, Screen.height - 50, playerStamina, 30),  "<color=#ffffff>" + "Stamina" + "</color>", skin.GetStyle("StaminaSkin")); 
        GUI.Box(new Rect(Screen.width /2  , Screen.height - 50, playerHealth, 30), "<color=#ffffff>" +"Health" + "</color>", skin.GetStyle("HealthSkin")); 

    }
}

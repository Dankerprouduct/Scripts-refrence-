using UnityEngine;
using System.Collections;

public class _GM : MonoBehaviour {

	// Use this for initialization

	void Start ()
    {
        
        Debug.Log("Made by: David Fitzgerald");
	}

     /* levels 
     * lv 0 is the titlescreen
     * lv 1 is the single player world 
     * lv 2 is the multiplayer world 
     * lv 3 is the controls screen 
     */ 
   
    

	void Update () {
        MenuLogic();

     
	}

    void MenuLogic()
    {

        if (Application.loadedLevel == 0 & Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); 
        }

        if (Application.loadedLevel == 1 & Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        else if (Application.loadedLevel == 2 & Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        else if (Application.loadedLevel == 3 & Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        else if (Application.loadedLevel == 4 & Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }

    }


}

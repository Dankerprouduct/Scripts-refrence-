using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Application.LoadLevel(4); 
        }
	}
    void OnGUI()
    {

        GUI.Label(new Rect(100, 70, 100, 100), "Made By David Fitzgerald    Build #0019"); 
   

        //.Label(new Rect(100, 70, 100, 100), "Made By Danker");

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 100, 50), "Single Player"))
        {

            Application.LoadLevel(1);
        }
        // make the multiplayer its own world (application.loadlevel(2) will be the multiplayer world)
        if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2, 100, 50), "Multiplayer"))
        {

            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Controls"))
        {
            Application.LoadLevel(3);
        }
    }
}

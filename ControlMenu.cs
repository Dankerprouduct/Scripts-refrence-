using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour {

    public float buffer;
    public float wBuffer; 

    public GUISkin skin; 

	
	void Start () {

        wBuffer = 0; 
    }
	
	void Update () {
	
	}
    
    void OnGUI()
    {
        GUI.skin = skin; 
        // first Column
        GUI.Box(new Rect(Screen.width / 2 - 500 + wBuffer, Screen.height /2 - 200 , 175,50), "W: Move forward", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 - 500 + wBuffer, Screen.height / 2 - 150 + buffer, 175, 50), "S: Move backward", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 - 500 + wBuffer, Screen.height / 2 - 100 + buffer * 2, 170, 50), "Space: Exit / De-equip", skin.GetStyle("Tooltip")); 

        // Second Column
        GUI.Box(new Rect(Screen.width / 2 - 250 + wBuffer, Screen.height / 2 - 200, 175, 50), "Left-Click: Fire/Select", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 - 250 + wBuffer, Screen.height / 2 - 150 + buffer, 175, 50), "E: Interact", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 - 250 + wBuffer, Screen.height / 2 - 100 + buffer * 2, 175, 50), "Tab: Open/Close Inventory", skin.GetStyle("Tooltip")); 

        // Third Column
        GUI.Box(new Rect(Screen.width / 2 + wBuffer, Screen.height / 2 - 200, 175, 50), "Right-Click: Select Item", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 + wBuffer, Screen.height / 2 - 150 + buffer, 175, 50), "#1 - #5: Quick Select", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 + wBuffer, Screen.height / 2 - 100 + buffer * 2, 175, 50), "LShift: Run", skin.GetStyle("Tooltip")); 
        
        //Fourth Column 
        GUI.Box(new Rect(Screen.width / 2 + 250 + wBuffer, Screen.height / 2 - 200, 175, 50), "R: Reload", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 + 250 + wBuffer, Screen.height / 2 - 150 + buffer, 175, 50), "L: New Gas Can", skin.GetStyle("Tooltip"));
        GUI.Box(new Rect(Screen.width / 2 + 250 + wBuffer, Screen.height / 2 - 100 + buffer * 2, 175, 50), "Esc: Leave Game", skin.GetStyle("Tooltip")); 
    }
}

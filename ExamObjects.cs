using UnityEngine;
using System.Collections;

public class ExamObjects : MonoBehaviour {

    bool showText; 
    public string ObjectDesc = "Input text here";

    public GUISkin skin;

	// Use this for initialization
	void Start () {
        showText = false; 	

	}


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                showText = true;
                Debug.Log(showText);
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        showText = false; 
    }


    void OnGUI()
    {
        GUI.skin = skin; 

        if (showText)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - 100, 150, 50), ObjectDesc, skin.GetStyle("Slot")); 
        }
    }
}

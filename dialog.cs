using UnityEngine;
using System.Collections;

public class dialog : MonoBehaviour {

	public string[] text; 
	bool ShowDialog = false;
	bool showText = false; 
	bool nextLine = false; 
	// Use this for initialization

	int index = 0; 

	void OnGUI(){
		if(ShowDialog == true && Input.GetKey(KeyCode.X)){
			showText = true;
			index++; 
		}
		if(index == text.Length){
			index = 0; 
		}
		if(index > text.Length){
			index = 0; 
		}

		if(nextLine == false & Input.GetKey(KeyCode.X)){
			nextLine = true; 
		}
		if(nextLine == true){
			index++;
			nextLine = false;
		}

		if(showText == true){
			Debug.Log("Button Pressed");

			GUI.contentColor = Color.blue;
			GUI.Label(new Rect(100, 50, Screen.width, Screen.height),text[index]);	

		}

	}




	void OnTriggerEnter2D(){
		ShowDialog = true;
	}
	void OnTriggerExit2D(){
		ShowDialog = false;
		showText = false; 
	}
}

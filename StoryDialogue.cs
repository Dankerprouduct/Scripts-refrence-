using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class StoryDialogue : MonoBehaviour {


    List<string> Level1Dialgue = new List<string>();
    SinglePlayerScript single; 

	// Use this for initialization
	void Start () {
        single = GameObject.FindGameObjectWithTag("Player").GetComponent<SinglePlayerScript>();

        //Dialogue();
        //SendSpeach(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Level1()
    {
        Level1Dialgue.Add("Hello, is the test subject number 626 ready?");
    }
    void SendSpeach()
    {
        single.Speak(Level1Dialgue[0], true);
        print(Level1Dialgue[0]);
    }
}

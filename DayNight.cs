using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	// Use this for initialization
    public float Night = 0f;
    public float Day = .1f;
    float time = .1f;

    bool upDown = true; 
    void Start () {
		time = .1f;
        Night = 0f;
        Day = .1f;
	}
	
	// Update is called once per frame
	
    

	void Update () {
		
        
		TIMER();
	}

	void TIMER(){

        GetComponent<Light>().intensity = time;
        

        if (time >= Day)
        {
            upDown = false; 
        }
        if (time <= 0)
        {
            upDown = true;
        }

        if (!upDown)
        {
            time = time - .0000001f;
        }
        if (upDown)
        {
            time = time + .0000001f;
        }
}
















}

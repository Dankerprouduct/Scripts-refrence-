using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {


	//bullet Attributes 
	public float bulSpeed = 10f;
	public float bulDestroy = 2f; 
	public int bulCount; 

	bool Saftey;
	bool Fire;

    public GameObject sBull; 
	// Use this for initialization
	void Start () {
		bulCount = 50;
		 
	}
	
	// Update is called once per frame
	void Update () {

        Empty(); 
		Safe(); 
		Firing(); 
	}
    void Empty()
    {
        if (bulCount <= 0)
        {
            bulCount = 0; 
        }
    }
	void Safe(){

		if(Input.GetKeyDown(KeyCode.V)){



			if(Saftey){
				Saftey = false;
				print("Safty" + Saftey);

			}
		
			if(!Saftey){
				Saftey = true;
				print("Safty" + Saftey); 

			}

		}

	}

	void Firing(){
		if(Input.GetButtonDown("Fire1") & Saftey == false){
			bulCount = bulCount - 1; 
			print("shots fired" + bulCount);

            sBull.GetComponent<Rigidbody>().AddForce(transform.forward * bulSpeed); 
            
		}
	}
}

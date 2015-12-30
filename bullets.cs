using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public GameObject bullet;

	bool safty =  false;
	void Update () {
		if(Input.GetKey(KeyCode.E) & safty == false){


			Instantiate(bullet, transform.position, Quaternion.identity);  


		}

	}
	void OnBecameInvisable(){
		Destroy(bullet); 
	}
}

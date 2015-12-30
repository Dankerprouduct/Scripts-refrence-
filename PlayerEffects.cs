using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour {
    public Transform poop; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         //   Instantiate(poop, transform.position, Quaternion.identity);
        }
	}

    public void Poop()
    {

       Instantiate(poop, transform.position, Quaternion.identity);

        
    }
}

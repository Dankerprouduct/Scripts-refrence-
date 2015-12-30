using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {

    private ZombieAi zombieAi; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            zombieAi = transform.parent.GetComponent<ZombieAi>();

            zombieAi.Movement();
        }
    }
}

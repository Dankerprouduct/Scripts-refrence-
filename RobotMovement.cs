using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour {


    private RobotAI robotAi; 
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
            print("moving");
            robotAi = transform.parent.GetComponent<RobotAI>();

            robotAi.MoveAttack(); 
        }
    }
}

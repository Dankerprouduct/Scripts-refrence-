using UnityEngine;
using System.Collections;

public class MultiTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    float speed = 1f;
	// Update is called once per frame
	void Update () {
	
	}

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * speed * Time.deltaTime);
        }
    }
}

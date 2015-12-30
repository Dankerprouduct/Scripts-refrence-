using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour
{

    Transform player; 


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }


    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(player, transform.position, transform.rotation);
                
                 
            }
        }
    }
}

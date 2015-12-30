using UnityEngine;
using System.Collections;

public class WaterMehcanics : MonoBehaviour
{

    float swimSpeed;

    private SinglePlayerScript player;
    // Use this for initialization
    void Start()
    {

        swimSpeed = .5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SetStats(true); 
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SetStats(false); 
        }
    } 
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<SinglePlayerScript>();
        }
    }
    void SetStats(bool sendInfo)
    {
        if (sendInfo)
        {
            player.StatSet(swimSpeed);
        }
        else
        {
            player.StatSet(1); 
        }
    }
}
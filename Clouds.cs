using UnityEngine;
using System.Collections;



public class Clouds : MonoBehaviour {

    // Use this for initialization

    bool interact = true;



    public Transform[] waypoints;

    private int currentIndex;
    private Transform currentWaypoint;

    float moveSpeed = .001f;
    float minDistance = .01f;

    void Start()
    {
        currentWaypoint = waypoints[0];
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (interact == true)
        {
            MoveTowardWaypoint();

            if (Vector3.Distance(currentWaypoint.transform.position, transform.position) < minDistance)
            {
                currentIndex++;

                if (currentIndex > waypoints.Length - 1)
                {
                    currentIndex = 0;

                }

                currentWaypoint = waypoints[currentIndex];
            }
        }
    }

    void MoveTowardWaypoint()
    {
        Vector3 direction = currentWaypoint.transform.position - transform.position;
        Vector3 moveVector = direction.normalized * moveSpeed; // *time.Delts
        transform.position += moveVector;

    }



    void OnTriggerEnter2D()
    {
        if (interact == true)
        {
            interact = false;
        }
        else
        {
            interact = true;
        }
    }
    void OnTriggerExit2D()
    {
        if (interact == true)
        {
            interact = true;
        }
        else
        {
            interact = true;
        }
    }

}

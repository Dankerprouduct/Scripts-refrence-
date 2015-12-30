using UnityEngine;
using System.Collections;

public class FollowSingleP : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
    Vector3 PlayerPOS;

    bool follw = true;
    float DistanceAway = 10f;

    public GameObject Dirtbike;

    // Update is called once per frame




    void Update()
    {



        if (follw == true)
        {
            PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position;
            GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
        }
        else
        {
            PlayerPOS = GameObject.Find("dirtbike").transform.transform.position;
            GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
        }
        
        

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().orthographicSize += 1; 
        }
        if (GetComponent<Camera>().orthographicSize <= 1)
        {
            GetComponent<Camera>().orthographicSize = 1; 
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().orthographicSize += -1; 
        }
        if (GetComponent<Camera>().orthographicSize >= 5)
        {
            GetComponent<Camera>().orthographicSize = 5;
        }
    }








    public void Veh()
    {

        follw = false;
    }
    public void Her()
    {
        follw = true;

    }
}

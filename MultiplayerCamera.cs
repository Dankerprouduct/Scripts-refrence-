using UnityEngine;
using System.Collections;

public class MultiplayerCamera : MonoBehaviour {


    // Use this for initialization

    Vector3 PlayerPOS;

    bool follw = true;
    float DistanceAway = 10f;

    public GameObject Dirtbike;
    Quaternion rotation; 
    // Update is called once per frame

    void Start()
    {
        PlayerPOS = transform.parent.transform.position; 
        rotation = transform.rotation; 
    }


    void LateUpdate()
    {
        
        if (GetComponent<NetworkView>().isMine)
        {
            GetComponent<Camera>().enabled = true;
            
            if (follw == true)
            {
                transform.rotation = rotation;
                PlayerPOS = transform.parent.transform.position;
                transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
            }
        }
        else
        {
            GetComponent<Camera>().enabled = false;
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

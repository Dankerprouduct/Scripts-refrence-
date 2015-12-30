using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	

	Vector3  PlayerPOS;
	
	bool follw = true; 
    float DistanceAway = 10f;

    public GameObject Dirtbike;
    public GameObject target;

    private Camera cam;

    public void myInitializeMethod(NetworkPlayer player)
    {
       
    }

    void Update()
    {


        

        if (GetComponent<NetworkView>().isMine)
        {

            cam.enabled = true; 

           /* if (follw == true)
            {

                PlayerPOS = GameObject.FindGameObjectWithTag("Player").transform.transform.position; 
               // GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
                print(PlayerPOS);  
                transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway); 
            }
            else
            {
                PlayerPOS = GameObject.Find("dirtbike").transform.transform.position;
                transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
            } */


        }
        else
        {
            cam.enabled = false; 
        }
        

        if (Input.GetKey(KeyCode.LeftBracket))
        {
            DistanceAway = DistanceAway - 1; 
        }
        if (Input.GetKey(KeyCode.RightBracket))
        {
            DistanceAway = DistanceAway + 1;
        }
    }








	void Veh(){

		follw = false; 
	}
    void Her()
    {
        follw = true;

    }
}

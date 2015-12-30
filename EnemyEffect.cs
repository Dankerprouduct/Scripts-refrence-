using UnityEngine;
using System.Collections;

public class EnemyEffect : MonoBehaviour {

    public Transform blood;
	// Use this for initialization
	void Start () {
        transform.Translate(new Vector3(0, 0, -1)); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ShowBlood()
    {
        print("Showing blood");
        Instantiate(blood, transform.position, Quaternion.identity);
    }
   
}

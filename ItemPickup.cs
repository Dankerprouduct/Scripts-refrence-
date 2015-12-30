using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {

  //  bool pickup; 
    private Inventory inventory;
    public int Id; 
	// Use this for initialization
	void Start ()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

   /* public void PickUp(bool pic)
    {
        pickup = pic;
        print(pickup); 
    } */

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventory.AddItem(Id);

                    Destroy(this.gameObject);
                }
            
        }
    }

}

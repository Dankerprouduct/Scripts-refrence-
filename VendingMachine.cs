using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class VendingMachine : MonoBehaviour {

    private Inventory inventory;
    List<int> items = new List<int>(); 

    int itemAmount;
    int min;
    int max; 

	
	void Start () {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        itemAmount = 1;

        items.Add(26);
        items.Add(16);
        items.Add(15);
        items.Add(9);
        items.Add(11);
        items.Add(8); 

        min = 0;
        max = items.Count; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            int index = Random.Range(min, max); 
            if (itemAmount >= 1)
            {
                inventory.AddItem(index);
                itemAmount = itemAmount - 1;
                StartCoroutine(Refill(300)); 
            }
        }
    }

    IEnumerator Refill(float time)
    {
        itemAmount++; 
        yield return new WaitForSeconds(time); 
    }

    
}

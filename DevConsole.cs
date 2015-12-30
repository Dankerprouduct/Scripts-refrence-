using UnityEngine;
using System.Collections;

public class DevConsole : MonoBehaviour {

    public string stringToEdit = "";
    int id;
    private Inventory inventory;

    bool show; 
	// Use this for initialization
	void Start () {

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>(); 
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.AddItem(41);
        }
        

       
	}

    
    void OnGUI()
    {
        if (show)
        {
            stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        }
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hands : MonoBehaviour {
    public int slotsX, slotsY;

    public GUISkin skin; 

    public List<Item> handInventory = new List<Item>(); 
    public List<Item> slots = new List<Item>();
    
    private ItemDatabase database;
    private Inventory rInventory; 

    private bool showInventory; 

    private string toolTip;
    private bool showTooltip;
    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex; 
	// Use this for initialization
	void Start () {

        for (int i = 0; i < slotsX * slotsY; i++)
        {
            slots.Add(new Item());
            handInventory.Add(new Item()); 
        }

            database = GameObject.Find("Item Database").GetComponent<ItemDatabase>();
            rInventory = GameObject.Find("Inventory").GetComponent<Inventory>();     

        AddItem(22); 
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showInventory = !showInventory;  
        }
	}
    
    void OnGUI()
    {
        toolTip = " "; 

        GUI.skin = skin; 

        if (showInventory)
        {
            DrawInventory();
            if (showTooltip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15, Event.current.mousePosition.y + 15, 200, 200), toolTip, skin.GetStyle("Tooltip"));
            }
        }
        if (draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
        }
    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;

        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);

                GUI.Box(slotRect, " ", skin.GetStyle("Slot"));

                slots[i] = handInventory[i];

                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        toolTip = CreateTooltip(slots[i]);
                        showTooltip = true;

                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            handInventory[i] = new Item();
                        }
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            handInventory[prevIndex] = handInventory[i];
                            handInventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;     
                        }
                    }
                }       
                else
                {
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            handInventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }


                    }
                    if (toolTip == " ")
                    {
                        showTooltip = false;
                    }

                    i++; 
                }
            }
        }

    }

    private void ToInventory(Item item, int slot, bool deleteItem)
    {

        switch (item.itemID)
        {
            case (22):
                {
                    break;
                }
        }
        
        if (deleteItem)
        {
            handInventory[slot] = new Item();
        
    }
    }

    string CreateTooltip(Item item)
    {
        toolTip = "<color=#ffffff>" + item.itemName + "</color>\n\n" + item.itemDesc;
        return toolTip;
    }



    public void AddItem(int id)
    {
        for (int i = 0; i < handInventory.Count; i++)
        {
            if (handInventory[i].itemName == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        handInventory[i] = database.items[j]; 
                    }
                }
                break; 
            }
        }
    }

}

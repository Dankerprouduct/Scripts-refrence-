using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public GUISkin skin; 
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>(); 
    private ItemDatabase database;

    private Vehicle vehicle; 
    private PlayerStats playStat;
    private Hands hands;
    private PlayerEffects playEffect; 

    private bool showInventory;

    private bool inVehicle; 

    private bool showTooltip;
    private string toolTip;

    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;

    private Projectile guns;

    private ItemPickup itemPick; 
    int invenMax;
    int invencount;

    private HeadGear headGear;

    bool canShwInven;

    // Use this for initialization
    void Start()
    {
        canShwInven = true; 
        invencount = 0;
        for (int i = 0; i < slotsX * slotsY; i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

       // InventoryMax();
        if (Application.loadedLevel != 2)
        {
            hands = GameObject.Find("Hands").GetComponent<Hands>();
            playStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
            vehicle = GameObject.Find("dirtbike").GetComponent<Vehicle>();
            guns = GameObject.FindGameObjectWithTag("Projectile").GetComponent<Projectile>();
            playEffect = GameObject.Find("PlayerEffects").GetComponent<PlayerEffects>();
            itemPick = GameObject.FindGameObjectWithTag("Item").GetComponent<ItemPickup>();
            headGear = GameObject.FindGameObjectWithTag("headGear").GetComponent<HeadGear>();
        }
       // AddItem(22);

    }
    public void MultiPlayerFind()
    {
        hands = GameObject.Find("Hands").GetComponent<Hands>();
        playStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        vehicle = GameObject.Find("dirtbike").GetComponent<Vehicle>();
        guns = GameObject.FindGameObjectWithTag("Projectile").GetComponent<Projectile>();
        playEffect = GameObject.Find("PlayerEffects").GetComponent<PlayerEffects>();
        itemPick = GameObject.FindGameObjectWithTag("Item").GetComponent<ItemPickup>();
        headGear = GameObject.FindGameObjectWithTag("headGear").GetComponent<HeadGear>();
    }
    void Update()
    {
        if (canShwInven)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                showInventory = !showInventory;
            }
        }
        SelectInvent();

      //  InventoryMax();
    }


    public void Ridding(bool can)
    {
        
        canShwInven = can;
        if (!can)
        {
            showInventory = false; 
        }
    }
 

    void OnGUI()
    {
        toolTip = " "; 

        GUI.skin = skin; 

        if(showInventory)
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
                Rect slotRect = new Rect(x * 60, y * 60 + 100, 50, 50); 
                GUI.Box(slotRect , " ", skin.GetStyle("Slot"));

                slots[i] = inventory[i];
               
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
                            inventory[i] = new Item(); 
                        }
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null; 
                        }
                        if (e.isMouse && e.type == EventType.MouseDown && e.button == 1)
                        {
                            if (slots[i].itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(slots[i], i, true); 
                            }
                            if (slots[i].itemType == Item.ItemType.Weapon)
                            {
                                ToHands(slots[i], i, false);
                                print(slots[i]); 
                                
                            }
                            if (slots[i].itemType == Item.ItemType.Clothing)
                            {
                                Clothing(slots[i], i, true); 
                            }
                            if (slots[i].itemType == Item.ItemType.Equipment)
                            {
                                UseEquipment(slots[i], i, true); 
                            }
                        }

                      
                        
                        
                    }

                }
                else
                {
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null; 
                        }

                        
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

    public void InVehicle(bool inV)
    {

    }
    void SelectInvent()
    {
        if (canShwInven)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                print(inventory[0].itemName);
                if (slots[0].itemType == Item.ItemType.Equipment)
                {
                    UseEquipment(inventory[0], 0, true);
                }
                if (slots[0].itemType == Item.ItemType.Weapon)
                {
                    ToHands(inventory[0], 0, true);
                }
                if (slots[0].itemType == Item.ItemType.Consumable)
                {
                    UseConsumable(inventory[0], 0, true);
                }
                if (slots[0].itemType == Item.ItemType.Clothing)
                {
                    Clothing(inventory[0], 0, true);    
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                print(inventory[1].itemName);
                if (slots[1].itemType == Item.ItemType.Equipment)
                {
                    UseEquipment(inventory[1], 1, true);
                }
                if (slots[1].itemType == Item.ItemType.Weapon)
                {
                    ToHands(inventory[1], 1, true);
                }
                if (slots[1].itemType == Item.ItemType.Consumable)
                {
                    UseConsumable(inventory[1], 1, true);
                }
                if (slots[1].itemType == Item.ItemType.Clothing)
                {
                    Clothing(inventory[1], 0, true); 
                }
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                print(inventory[2].itemName);
                if (slots[2].itemType == Item.ItemType.Equipment)
                {
                    UseEquipment(inventory[2], 2, true);
                }
                if (slots[2].itemType == Item.ItemType.Weapon)
                {
                    ToHands(inventory[2], 2, true);
                }
                if (slots[2].itemType == Item.ItemType.Consumable)
                {
                    UseConsumable(inventory[2], 2, true);
                }
                if (slots[2].itemType == Item.ItemType.Clothing)
                {
                    Clothing(inventory[2], 2, true); 
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                print(inventory[3].itemName);
                if (slots[3].itemType == Item.ItemType.Equipment)
                {
                    UseEquipment(inventory[3], 3, true);
                }
                if (slots[3].itemType == Item.ItemType.Weapon)
                {
                    ToHands(inventory[3], 3, true);
                }
                if (slots[3].itemType == Item.ItemType.Consumable)
                {
                    UseConsumable(inventory[3], 3, true);
                }
                if (slots[3].itemType == Item.ItemType.Clothing)
                {
                    Clothing(inventory[3], 3, true); 
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                print(inventory[4].itemName);
                if (slots[4].itemType == Item.ItemType.Equipment)
                {
                    UseEquipment(inventory[4], 4, true);
                }
                if (slots[4].itemType == Item.ItemType.Weapon)
                {
                    ToHands(inventory[4], 4, true);
                }
                if (slots[4].itemType == Item.ItemType.Consumable)
                {
                    UseConsumable(inventory[4], 4, true);
                }
                if (slots[4].itemType == Item.ItemType.Clothing)
                {
                    Clothing(inventory[4], 4, true); 
                }
            }
        }
    }
    private void Clothing(Item item, int slot, bool deleteItem)
    {

        switch (item.itemID)
        {
            case (52):
                {
                    headGear.ChangeHeadgear(item.itemID);
                    break; 
                }
            case (44):
                {
                    headGear.ChangeHeadgear(item.itemID); 
                    break; 
                }
            case (45):
                {
                    headGear.ChangeHeadgear(item.itemID);
                    break;
                }
            case (46):
                {
                    headGear.ChangeHeadgear(item.itemID);
                    break; 
                }
            case (47):
                {
                    headGear.ChangeHeadgear(item.itemID);
                    break; 
                }
            case (53):
                {
                    headGear.ChangeHeadgear(item.itemID);
                    break;
                }
                
        }

        if (deleteItem)
        {
            invencount = invencount - 1;
            inventory[slot] = new Item();
        }
    }

    private void UseEquipment(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case (41):
                {
                   
                    vehicle.AddGas(item.itemPower);
                     break;
                }
            case (40):
                {
                    print("Ammo added"); 
                    guns.AddBullets(item.itemPower); 
                    break; 
                }
        }

        if (deleteItem)
        {
            invencount = invencount - 1;
            inventory[slot] = new Item();
        }
    }

    private void UseConsumable(Item item, int slot, bool deleteItem)
    {
         
        switch (item.itemID)
        {
            case (39):
                {
                    playStat.IncreaseHealth(item.itemPower);
                    break; 
                }
            case (38):
                {
                    playStat.IncreaseHealth(item.itemPower);
                    break; 
                }
            case (17):
                {
                    for (int i = 0; i < 3; i++)
                    {
                        playStat.IncreaseHealth(item.itemPower);
                    }
                    break; 
                }

            case (19):
                {
                    playStat.IncreaseHunger(item.itemPower);
                    playStat.IncreaseHealth(item.itemSpeed);
                    break; 
                }
            case (44):
                {
                    playStat.IncreaseThirst(item.itemPower);
                    break;
                }
            case (37):
                {
                    playStat.IncreaseHealth(item.itemPower); 
                    break; 
                }
            case (5):
                {

                    playEffect.Poop(); 
                    playStat.IncreaseHunger(item.itemPower);
                    playStat.IncreaseThirst(item.itemPower);
                    break; 
                }

            case (41):
                {
                    print("gas add");
                    vehicle.AddGas(item.itemPower);
                    break;
                }

            case (8):
                {
                    // water bottle

                    //playStats.IncreaseThirst(item.itemPower); 
                    playStat.IncreaseThirst(item.itemPower); 

                    break;
                }
            case (9):
                {
                    playStat.IncreaseHunger(item.itemPower); 
                    break;
                }
            case (10):
                {
                    playStat.IncreaseHunger(item.itemPower); 
                    break;
                }
            case (11):
                {
                    playStat.IncreaseHunger(item.itemPower); 
                    break;
                }
            case (12):
                {
                    playStat.IncreaseHunger(item.itemPower);
                    break;
                }
            case (13):
                {
                    playStat.IncreaseHunger(item.itemPower); 
                    break;
                }
            case (14):
                {
                    playStat.IncreaseHunger(item.itemPower); 
                    break;
                }
            case (15):
                {
                    playStat.IncreaseHunger(item.itemPower);
                    break;
                }
            case (16):
                {
                    playStat.IncreaseThirst(item.itemPower);
                    break; 
                }
            case (18):
                {
                    playStat.IncreaseHunger(item.itemPower);
                    break;
                }
            case (20):
                {
                    playStat.IncreaseThirst(item.itemPower);
                    break;
                }
            case (25):
                {
                    playStat.IncreaseHealth(item.itemPower);
                    break; 
                }
            case (26):
                {
                    playStat.IncreaseThirst(item.itemPower);
                    break; 
                }
            case (27):
                {
                    playStat.IncreaseThirst(item.itemPower);
                    break;
                }
            
           
            

        }
        if (deleteItem)
        {
            invencount = invencount - 1; 
            inventory[slot] = new Item(); 
        }
    }





    private void ToHands(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case (22):
                {

                    guns.ChangeGun(1);
                    break;
                }
            case (23):
                {
                    guns.ChangeGun(2);
                    break;
                }
            case (32):
                {
                    guns.ChangeGun(3);
                    break; 
                }
            case (43):
                {
                    guns.ChangeGun(4);
                    break; 
                }
            case (42):
                {
                    guns.ChangeGun(5);
                    break; 
                }
        }


    }

    string CreateTooltip(Item item)
    {
        toolTip = "<color=#ffffff>" + item.itemName + "</color>\n\n" + item.itemDesc;
        return toolTip; 
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item(); 
                break; 
            }
        }
    }

    public void AddItem(int id)
    {

        invencount = invencount + 1; 
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                
                for(int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];  
                    }
                }

                break; 
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result= false; 

        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break; 
            }
        }
        return result; 
    }
 

}

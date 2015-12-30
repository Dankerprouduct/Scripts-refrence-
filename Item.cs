using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{


    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int itemPower;
    public int itemSpeed;
    public ItemType itemType; 

    public enum ItemType
    {
        Weapon, 
        Consumable, 
        Quest, // change to wearable item or clothing
        Clothing,
        Equipment
    }

    public Item(string name, int ID, string Desc, int Power, int Speed, ItemType type)
    {
        itemName = name;
        itemID = ID;
        itemDesc = Desc;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemPower = Power;
        itemSpeed = Speed;
        itemType = type; 
    }
    public Item()
    {

    }
    
}

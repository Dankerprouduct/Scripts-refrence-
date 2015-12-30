using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    void Awake()
    {
        // Clothing
        items.Add(new Item("Empy", 0, " ", 0, 0, Item.ItemType.Clothing));
        items.Add(new Item("White Shirt", 1, "A shirt that is white", 2, 0, Item.ItemType.Clothing));
        items.Add(new Item("Orange Hat", 44,"An awesome hat that hasnt been washed since its purchase in 1999", 0, 0,Item.ItemType.Clothing));
        items.Add(new Item("Red Hat", 45, "A Hat that is red, yep, not much to it", 0, 0, Item.ItemType.Clothing));
        items.Add(new Item("White Hat", 46, "White Hat made by Galvin Bine", 0, 0, Item.ItemType.Clothing));
        items.Add(new Item("Black Hat", 47, "Just your regular BLACK hat, nothing wrong with that right?", 0, 0, Item.ItemType.Clothing));


        items.Add(new Item("School Bookbag", 48, "A Yellow Mitty bookbag", 5, 0, Item.ItemType.Clothing));
        items.Add(new Item("Travel Bag", 49, "A bag used if going on a family trip... if they're not zombies yet", 10, 0, Item.ItemType.Clothing));
        items.Add(new Item("Military Pack", 50, "Camo bookbag", 20, 0, Item.ItemType.Clothing));
        items.Add(new Item("Barbarian Hat", 52, " ", 0, 0, Item.ItemType.Clothing));
        items.Add(new Item("Blue Goggles", 53, " ", 0, 0, Item.ItemType.Clothing)); 

        // Consumables
        items.Add(new Item("Power Potion", 2, "Really just kool-aid", 3, 0, Item.ItemType.Consumable));
        items.Add(new Item("Antidote", 3, "Drink this and you'll feel better. I promise you!", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Zombie Virus", 4, "Extracted blood from zombies", -100, 0, Item.ItemType.Consumable));
        items.Add(new Item("Laxative", 5, "Put this in a frenemy's food for a laugh", -50, 0, Item.ItemType.Consumable));
        items.Add(new Item("Invincibility", 6, "BE SUPER MAN!", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Invisibility", 7, "you wont have to take of your clothes for this... unless you want to", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Water Bottle", 8, "a bottle filled with fish air", 75, 0, Item.ItemType.Consumable));
        items.Add(new Item("Apple", 9, "not the laptop, but the food", 40, 0, Item.ItemType.Consumable));
        items.Add(new Item("Rotten Apple", 10, "Why you would eat this is beyond me", 20, -5, Item.ItemType.Consumable));
        items.Add(new Item("Bannana", 11, "Bannana, nouf said", 40, 0, Item.ItemType.Consumable));
        items.Add(new Item("Hamburger", 12, "a nice juicy slice of cow", 70, 0, Item.ItemType.Consumable));
        items.Add(new Item("Cup Of Noodles", 13, "who doesnt love noodles other than Hitler", 50, 0, Item.ItemType.Consumable));
        items.Add(new Item("Hotdog", 14, "Made with scrap meat that nobody likes", 30, 0, Item.ItemType.Consumable)); 
        items.Add(new Item("Potato Chips", 15,"half heaven, half air", 50,0, Item.ItemType.Consumable)); 
        items.Add(new Item("Grape Soda", 16, "Dont promote stereotypes", 30,0, Item.ItemType.Consumable));
        items.Add(new Item("Orange Soda", 26, "I would call it a F&NTA but i'm afraid of copyright", 30, 0, Item.ItemType.Consumable));
        items.Add(new Item("Rat Poison", 17, "I love the smell of poison in the morning", -30,0, Item.ItemType.Consumable)); 
        items.Add(new Item("Pickle", 18, "PICKLES, PICKLES, GET YOUR OWN LONG, THICK AND JUICY PICKLE!!", 15,0,Item.ItemType.Consumable));
        items.Add(new Item("Moldy Bannana", 19, "Please, just starve", 14, -10, Item.ItemType.Consumable));
        items.Add(new Item("Apple Juice", 20, "lets just hope that its not urine", 25,0, Item.ItemType.Consumable));
        items.Add(new Item("Healing Potion", 25, "A potion for healing", 75, 0, Item.ItemType.Consumable));
        items.Add(new Item("Milk", 27, "got milk?", 70, 0, Item.ItemType.Consumable));
        items.Add(new Item("Spoiled Milk", 28, "It's perfectly good cheese, really.", 25, -10, Item.ItemType.Consumable));
        items.Add(new Item("Small Med Pack", 37, "it's only a scratch, brush it off", 25, 0, Item.ItemType.Consumable));
        items.Add(new Item("Medium Med Pack", 38, "come on, get up and stop acting like a baby", 60, 0, Item.ItemType.Consumable));
        items.Add(new Item("Large Med Pack", 39, "you better of been recently shot", 100, 0, Item.ItemType.Consumable));
        items.Add(new Item("Apple Juice", 51, "Awesome Liquid, good fo' yo soul", 65, 0, Item.ItemType.Consumable)); 
       
        //Equipment 
        items.Add(new Item("gPhone", 21, "gPhone, You'll buy whatever we tell you to", 0, 0, Item.ItemType.Equipment));
        items.Add(new Item("Rope", 24, "dont see why you need this", 0, 0, Item.ItemType.Equipment));
        items.Add(new Item("Laptop", 30, "Awesome laptop running Danker 2.0", 0, 0, Item.ItemType.Equipment));
        items.Add(new Item("Flashlight", 31, "awww is someone afraid of the dark?", 0, 0, Item.ItemType.Equipment));
        items.Add(new Item("Drone Arm", 33, "If found please return to AD-#9012", 0, 0, Item.ItemType.Equipment));
        items.Add(new Item("Drone Base", 34, "Hehe, this is Robot booty", 0, 0, Item.ItemType.Equipment)); 
        items.Add(new Item("Drone CPU", 35, "Decades of technology used to develop the worlds first self-aware robot brain is now used for a toy helicopter", 0,0, Item.ItemType.Equipment));
        items.Add(new Item("Rc Controller", 36, "6 channel RC Controller", 0, 0, Item.ItemType.Equipment)); 
        items.Add(new Item("Ammo Box", 40, "What good are guns without bullets?",50,0, Item.ItemType.Equipment));
        items.Add(new Item("Gas Can", 41, "A can filled With Gas",50,0, Item.ItemType.Consumable)); 

        //Weapons
        items.Add(new Item("Pistol", 22, "this can help your problems go away", 5, 0, Item.ItemType.Weapon));
        items.Add(new Item("Revolver", 23, " D'jango was an awesome movie", 7, 0, Item.ItemType.Weapon));
        items.Add(new Item("Grenade", 29, "And boom goes the dynomite", 10, 0, Item.ItemType.Weapon));
        items.Add(new Item("Double Barrel Shotgun", 32, "A great gun for a great person... Not you David Fitzgerald of course", 0, 0, Item.ItemType.Weapon));
        items.Add(new Item("Machine Gun", 42, "Got shaky hands? This is the perfect gun for you!", 0, 0, Item.ItemType.Weapon));
        items.Add(new Item("LazerGun", 43, "I don't know where it comes from, but it makes a cool noise", 0,0,Item.ItemType.Weapon)); 
    }


}

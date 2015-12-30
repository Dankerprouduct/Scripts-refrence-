using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class HeadGear : MonoBehaviour {


     public SpriteRenderer sr;

     public List<Sprite> headGear = new List<Sprite>();

     private Inventory inventory;

     int CurWearing; 

	void Start () {

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>(); 

        sr.enabled = true;
        Hide();
        Show(); 
	}
	
	
	void Update () {
	
	}

    public void Hide()
    {
        sr.enabled = false; 
    }
    public void Show()
    {
        sr.enabled = true;
    }

    public void ChangeHeadgear(int id)
    {
        
        switch (id)
        {
            
            case (0):
                {
                    ChangeBack(CurWearing);
                    sr.enabled = false; 
                    break; 
                }
            case (53):
                {
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    sr.enabled = true;
                    sr.sprite = headGear[5];
                    CurWearing = 53;
                    break;
                }
            case (52):
                {
                    // Barbarian Hat
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    sr.enabled = true;
                    sr.sprite = headGear[0];
                    CurWearing = 52; 
                    break;
                }
            case (44):
                {
                    // Orange Hat
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    sr.enabled = true; 
                    sr.sprite = headGear[1];
                    CurWearing = 44; 
                    break; 
                }
            case (45):
                {
                    // Red Hat
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    sr.enabled = true;
                    sr.sprite = headGear[2];
                    CurWearing = 45; 
                    break;
                }
            case (46):
                {
                    // White Hat
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    print("White Hat");
                    sr.enabled = true;
                    sr.sprite = headGear[3];
                    CurWearing = 46; 
                    break; 
                }
            case (47):
                {
                    // Black Hat
                    if (sr.sprite != null)
                    {
                        ChangeBack(CurWearing);
                    }
                    sr.enabled = true; 
                    sr.sprite = headGear[4];
                    CurWearing = 47;
                    break; 
                }
            }
        }

        public void ChangeBack(int change){
            inventory.AddItem(change); 
        }

    }


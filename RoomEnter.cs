using UnityEngine;
using System.Collections;

public class RoomEnter : MonoBehaviour {


    public SpriteRenderer spriteRen;

    void Start()
    {
        spriteRen.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRen.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRen.enabled = true;
        }
    }
}

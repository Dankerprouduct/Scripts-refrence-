using UnityEngine;
using System.Collections;

public class CyclopsAI : MonoBehaviour {

    bool passive;
    bool attack;
    bool alive;

    float xDiff;
    float yDiff;

    Vector3 player;
    Vector2 playerDirection;

    int speed; 

    void Start()
    {
        passive = true;
        attack = true;
        alive = true;

        player = GameObject.FindGameObjectWithTag("Player").transform.position;

        speed = 1; 
    }

    void Update()
    {
        Attack(); 
        if (alive)
        {
            Behavior(); 
        }
    }

    void Behavior()
    {
        if (passive)
        {
            attack = false; 
        }
        if (passive == false)
        {
            print("passive is " + passive);
            attack = true; 
            Attack(); 
        }
    }

    void Attack()
    {
        if (attack)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform.position;
            xDiff = player.x - transform.position.x;
            yDiff = player.y - transform.position.y;

            playerDirection = new Vector2(xDiff, yDiff);
            
                Vector2 lookAtplayer = player - transform.position;
                float angle = Mathf.Atan2(lookAtplayer.x, lookAtplayer.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, -1 * Vector3.forward);

                GetComponent<Rigidbody2D>().AddForce(playerDirection);
                GetComponent<Rigidbody2D>().velocity = playerDirection * speed;

        }
    }
    public void Passiveness()
    {
        passive = false; 
    }
    void Die()
    {
        alive = false;
        attack = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
    }


}

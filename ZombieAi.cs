using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class ZombieAi : MonoBehaviour {

    private SpriteRenderer spriteRend;
    public Sprite spriteAlive;
    public Sprite spriteDead;

    public ZombieAttack attackScript; 

    bool alive; 
	// Use this for initialization

    public List<Transform>droppedItem = new List<Transform>();
    int min;
    int max;

 
    int dropable; 

	float xDiff;
	float yDiff; 
	public float speed = 1f; 
	Vector3 Player; 
	Vector2 PlayerDirection; 
	
	public Transform PlayerPos;
	float PlayDistance;
    bool attack = false;

    void Start()
    {
        min = 0;
        max = droppedItem.Count;

        dropable = 1;

        attackScript = transform.FindChild("Attack").GetComponent<ZombieAttack>(); 

        spriteRend = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
        alive = true;
        if (spriteRend.sprite == null)
        {
            spriteRend.sprite = spriteAlive; 
        } 
    }

	void Update () {
        if (alive)
        {
            // Finds Player
            Player = GameObject.FindGameObjectWithTag("Player").transform.position;
            xDiff = Player.x - transform.position.x;
            yDiff = Player.y - transform.position.y;
            PlayerDirection = new Vector2(xDiff, yDiff);
        }
        
	}

	public void Movement(){

        
            if(alive)
            {
                LookAtPlayer();

                attack = true;

                if (attack)
                {
                    if (attack)
                    {

                        GetComponent<Rigidbody2D>().AddForce(PlayerDirection);
                        GetComponent<Rigidbody2D>().velocity = PlayerDirection * speed;
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    }
                }
            
        }
	}
	void OnTriggerExit2D(){
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (alive)
        {
            attack = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
	}



	void LookAtPlayer(){

        if (alive)
        {
            if (attack)
            {
                Vector2 LookAtPlayer = Player - transform.position;
                float angle = Mathf.Atan2(LookAtPlayer.y, LookAtPlayer.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
	}

    void Die()
    {
        attackScript.Die(false);
        alive = false;
        spriteRend.sprite = spriteDead; 
        Destroy(this.gameObject, 5);
        // we could just destroy the zombie but first create the prefab of just the sprite
        if (dropable == 1)
        {
            int index = Random.Range(min, max);
            Instantiate(droppedItem[index], transform.position, transform.rotation);
        }
        dropable = dropable - 1; 
    }
}






















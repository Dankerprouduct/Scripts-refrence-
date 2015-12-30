using UnityEngine;
using System.Collections;

public class RobotAI : MonoBehaviour {

    private PlayerStats playerStats;

    public Transform bulletTrailPrefab;
    Transform firePoint;
    Vector2 playerDirection; 
    Vector3 player;

    bool alive;
    bool attck; 

    float xDiff;
    float yDiff;

    float speed;

    public LayerMask canHit; 

    int travDist = 8;
    void Start()
    {
        speed = .1f; 

        attck = false; 
        alive = true;
        firePoint = transform.FindChild("LazerPoint"); 
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); 
    }

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            attck = true;
            Shoot(); 
        }
    } 

    public void MoveAttack()
    {
        if (alive)
        {
            attck = true;
            Movement();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
        }
    }
    void Movement()
    {
        if (alive)
        {
            
                player = GameObject.FindGameObjectWithTag("Player").transform.position;
                xDiff = player.x - transform.position.x;
                yDiff = player.y - transform.position.y;
                
                playerDirection = new Vector2(xDiff, yDiff);
                attck = true; 
                if (attck)
                {
                    Vector2 lookAtplayer = player - transform.position;
                    float angle = Mathf.Atan2(lookAtplayer.x, lookAtplayer.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, -1 * Vector3.forward);

                    GetComponent<Rigidbody2D>().AddForce(playerDirection);
                    GetComponent<Rigidbody2D>().velocity = playerDirection * speed;

                    Shoot();
                }
            
        }
    }
    void Die()
    {
        alive = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Destroy(this.gameObject, 5f); 
    }
    void Shoot()
    {
        Vector2 playerPos = new Vector2(player.x, player.y);

        Vector2 firPosition = new Vector2(firePoint.position.x, firePoint.position.y); 

        RaycastHit2D hit = Physics2D.Raycast(firPosition, playerPos - firPosition, travDist, canHit);

       // Debug.DrawLine(firPosition, (playerPos - firPosition) * 100, Color.red);

        if (alive)
        {
            if (hit.rigidbody.GetComponent<Rigidbody2D>() != null)
            {
                Debug.DrawLine(firPosition, hit.point, Color.red);
                Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
                playerStats.IncreaseHealth(-.1f);
            }
        }

    }

}


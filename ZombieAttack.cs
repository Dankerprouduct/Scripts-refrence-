using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {
    PlayerStats playstat; 
	// Use this for initialization


    bool attack; 
	void Start () 
    {
        attack = true;
        playstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); 
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerStay2D(Collider2D other)
    {

        if (attack)
        {
            if (other.tag == "Player")
            {
                print("attack is " + attack);
                playstat.IncreaseHealth(-.1f);
            }
        }
    }
    public void Die(bool a)
    {
        attack = a;
        print(attack);
        if (!attack)
        {
            Destroy(this.gameObject); 
        }
    }

}

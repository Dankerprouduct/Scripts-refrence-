using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float Health;
    public Transform blood;
    public GameObject enemy;

    private EnemyEffect effect;
    private CyclopsAI cyclops; 

    public bool showBlood;
    public bool passiveMob; 

	// Use this for initialization
	void Start () {
       // effect = GameObject.FindGameObjectWithTag("PlayerEffects").GetComponent<EnemyEffect>(); 
        // write cylcops \/
        cyclops = GameObject.FindGameObjectWithTag("Cyclops").GetComponent<CyclopsAI>(); 
                        
	}
	
	// Update is called once per frame
	void Update () {

        if (Health <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            enemy.SendMessage("Die"); 
        }
	}
    public void TakeDamage(float dam)
    {
        Health = Health - dam;
        if (showBlood)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
        }
            //effect.ShowBlood();
        if (passiveMob)
        {
            cyclops.Passiveness(); 
        }
    }
}

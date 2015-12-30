using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class EnemySpawning : MonoBehaviour {

    bool waitActive; 

    public Transform zombie;
 //   public Transform robot; 

    public List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> enemySpawned = new List<Transform>();

	// Use this for initialization
	void Start () 
    {

        if (Application.loadedLevel == 1)
        {
            Spawn(); 
        }
        /*
        if (Application.loadedLevel == 2)
        {
            ServerSpawn(); 
        }     */    
        
	}


    void Spawn()
    {
        int min = 0;
        int max = enemySpawned.Count; 

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int index = Random.Range(min, max);
            //print(index); 
            Instantiate(enemySpawned[index], spawnPoints[i].position, spawnPoints[i].rotation);
        }


       StartCoroutine(SpawnTimer(900f));  
        
    }

    void ServerSpawn()
    {
        int min = 0;
        int max = enemySpawned.Count;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int index = Random.Range(min, max);
            //print(index); 
            Network.Instantiate(enemySpawned[index], spawnPoints[i].position, spawnPoints[i].rotation,0);
        }


        StartCoroutine(SpawnTimer(900f));  
        
    }
    IEnumerator SpawnTimer(float waitTime)
    {
        
        
        yield return new WaitForSeconds(waitTime);

        if (Application.loadedLevel == 1)
        {
            Spawn();
        }
        if (Application.loadedLevel == 2)
        {
            ServerSpawn();
        }
    }
	
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class ItemSpawns : MonoBehaviour {

    public List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> spawnItems = new List<Transform>();
    int min;
    int max;

	void Start () {

        min = 0;
        max = spawnItems.Count;

        if (Application.loadedLevel == 1)
        {
            Spawn();
        }
        if (Application.loadedLevel == 2)
        {
            ServerSpawn();
        }

   	}
	
	void Update () {
	
	}

    private void Spawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int index = Random.Range(min, max); 


            Instantiate(spawnItems[index], spawnPoints[i].position, spawnPoints[i].rotation); 
        }
        StartCoroutine(Respond(900)); 
    }
    private void ServerSpawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int index = Random.Range(min, max);
            //Network.Instantiate(spawnItems[index], new Vector2(spawnPoints[i].position.x, spawnPoints[i].position.y), spawnPoints[i].rotation, 0); 
        }
        StartCoroutine(Respond(900)); 
    }
    IEnumerator Respond(float waitTime)
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

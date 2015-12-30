using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class NetworkManager : MonoBehaviour {

    private Vehicle vehicle;
    private Inventory inventory; 

    public List<Transform> itemSpawns = new List<Transform>();
    public List<GameObject> itemPrefabs = new List<GameObject>(); 
    
    public List<Transform> enemySpawns = new List<Transform>();
    public List<GameObject> enemyPrefabs = new List<GameObject>(); 
    

    private MultiplayerCamera camera; 

    private const string typeName = "Continuance";
    private const string gameName = "Continuance Server";

    private HostData[] hostList;

    public GameObject playerPrefab; 

    public List<Transform>spawnPoints = new List<Transform>();

    int minSpawn; 
    int maxSpawn;

    void Start()
    {
        vehicle = GameObject.Find("dirtbike").GetComponent<Vehicle>(); 
       // camera = GameObject.Find("Main Camera").GetComponent<MultiplayerCamera>(); 
    }

    private void StartServer()
    {
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName); 

        minSpawn = 0; 
        maxSpawn = spawnPoints.Count;

        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            if (child.tag == "Item")
            {
                itemSpawns.Add(child);
            }
            if (child.tag == "EnemySpawn")
            {
                enemySpawns.Add(child); 
            }
        }

        SpawnItems();
        SpawnEnemy();
        SpawnPlayer();

        
    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initialized");
       // SpawnPlayer(); 
    }

    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                StartServer();
            }
            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
            {
                RefreshHostList();
            }
            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                    {
                        JoinServer(hostList[i]); 
                    }
                }
            }

        }
    }

    private void RefreshHostList()
    {
        MasterServer.RequestHostList(typeName);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.HostListReceived)
        {
            hostList = MasterServer.PollHostList(); 
        }
    }

    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData); 
    }

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
        SpawnPlayer(); 
    }

    void SpawnItems()
    {
        for (int i = 0; i > itemSpawns.Count; i++)
        {
            int index = Random.Range(0, itemPrefabs.Count);

            Network.Instantiate(itemPrefabs[index], new Vector2(itemSpawns[i].position.x, itemSpawns[i].position.y), itemSpawns[i].rotation, 0);
            print("spawning "+ itemPrefabs[index].name); 
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i > enemySpawns.Count; i++)
        {
            int index = Random.Range(0, enemyPrefabs.Count);

            Network.Instantiate(enemyPrefabs[index], new Vector2(enemySpawns[i].position.x, enemySpawns[i].position.y), enemySpawns[i].rotation, 0);
            print("spawning "+ enemyPrefabs[index].name); 
        }
    }
        
    void SpawnPlayer()
    {
        int index = Random.Range(minSpawn, maxSpawn);
        
        Network.Instantiate(playerPrefab, new Vector2(spawnPoints[index].transform.position.x, spawnPoints[index].position.y), spawnPoints[index].rotation, 0);
        print("spawning " + playerPrefab.name); 

        vehicle.multiPLayerFind();
        inventory.MultiPlayerFind(); 
    }

}

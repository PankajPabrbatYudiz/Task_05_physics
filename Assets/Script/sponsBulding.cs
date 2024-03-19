using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class sponsBulding : MonoBehaviour
{
    public static sponsBulding spone;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rigidbodyPrefab;
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private GameObject coins;
    private float generatTime = 0.01f;
    private float currentGenerationTime;

    public float tmp =0;

    [SerializeField] public float fixedPosition = 8f; 
 
    private float xSize = 0f;
    private float ySize = 0f;
    public float moveSpeed = 0.5f;
    public float buildingDistance = 5f;

    private List<GameObject> building_list = new List<GameObject>();
    gameManeger gm;
   public float lastBuildingXPosition = -37f;
    private float distanceBetweenBuildings = 8f;
    
    private void Awake()
    {
        if (spone == null)

        {
            spone = this;
        }
    }
    private void Start()
    {
        SpawnInitialBuildings();       
    }

    void Update()
    {

            DestroyBuildings();
            DestroyCoins();
        
       
    }

   


    void SpawnInitialBuildings()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnBuilding();
           
        }
    }

    void SpawnBuilding()
    {
        Vector2 spawnPosition = new Vector2(lastBuildingXPosition + distanceBetweenBuildings, 0.7f);

      
        buildingPrefab.transform.localScale = new Vector2(1.3f, Random.Range(0.2f, 0.8f));
        GameObject newBuilding = Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
      
        float topPosition = newBuilding.transform.position.y + (newBuilding.transform.localScale.y*tmp +2);

        // Instantiate coins at the top of the building
        GameObject coin = Instantiate(coins, new Vector2(spawnPosition.x, topPosition), Quaternion.identity);

        lastBuildingXPosition = spawnPosition.x;

     //   Debug.Log("lastBuildingXPosition " + lastBuildingXPosition);
       
    }




   
    public void DestroyCoins()
    {
        // Check each building and destroy it if the player has crossed it and they are a certain distance apart
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");

        foreach (var iscoins in coins)
        {
            if (player != null)
            {

                if (iscoins.transform.position.x < player.transform.position.x - 20f)
                {
                    Destroy(iscoins);
                  
                }
            }
        }
    }


  

    public void DestroyBuildings()
    {
        // Check each building and destroy it if the player has crossed it and they are a certain distance apart
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach (var building in buildings)
        {
            if (player != null)
            {

                if (building.transform.position.x < player.transform.position.x - 15f)
                {
                    Destroy(building);
                    SpawnBuilding();
                }
            }
        }
    }
}


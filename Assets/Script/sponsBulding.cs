using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class sponsBulding : MonoBehaviour
{
       
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject coins;
    private float generatTime = 0.1f;
    private float currentGenerationTime;

    [SerializeField] public float fixedPosition = 0f; // Set fixedPosition to 0
 
    private float xSize = 0f;
    private float ySize = 0f;
    public float moveSpeed = 0.5f;
    public float buildingDistance = 5f;

    private List<GameObject> building_list = new List<GameObject>();
    gameManeger gm;

    private void Start()
    {       
        SpawnInitialBuildings();
            
       
    }

    void Update()
    {
        currentGenerationTime += Time.deltaTime;        
            if (currentGenerationTime > generatTime )
            {
                startBulding();
                currentGenerationTime = 0;
            }     
        DestroyCoins();
    }

   

    private void startBulding()
    {
       // transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

    
     if(player!= null)
        {
            if (player.transform.position.x >= building_list[3].transform.position.x)
            {
                Destroy(building_list[0]);
                building_list.RemoveAt(0);

                SpawnBuilding();
            }
        }

       
    }

    void SpawnInitialBuildings()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnBuilding();
           
        }
    }

    void SpawnBuilding()
    {
        Vector3 buildingPosition;
        if (building_list.Count == 0)
            buildingPosition = new Vector3(transform.position.x, 0, 0);
     
        else
            buildingPosition = new Vector3(building_list[building_list.Count - 1].transform.position.x + buildingDistance,
                                           0, 0);
      //  Debug.Log("building_list[building_list.Count - 1] " + building_list[building_list.Count - 1]);
        GameObject newBuilding = Instantiate(building, buildingPosition, transform.rotation);



        int buildingHeight = Random.Range(2, 7);

        int buildingWidth = Random.Range(2, 4);
        float bottomPosition = newBuilding.transform.position.y - newBuilding.transform.localScale.y / 2f;
        Debug.Log("bottom Y posion "+bottomPosition);//bottom Y posion -2.81765 always same 
        //here i found out the bottom y position
        newBuilding.transform.localScale = new Vector3(buildingWidth, buildingHeight, newBuilding.transform.localScale.z);
        Debug.Log(" newBuilding.transform.localScale " + newBuilding.transform.localScale);//newBuilding.transform.localScale (2.00, 4.00, 1.00)
        //its a local posion its changes continuously
        float newYPosi = bottomPosition + newBuilding.transform.localScale.y / 2f;
        Debug.Log("newYPosition " + newYPosi);
        //  newYPosition - 0.3176501
        // Its changes continuously
        //its calculate y position
        newBuilding.transform.position = new Vector3(newBuilding.transform.position.x, newYPosi, newBuilding.transform.position.z);
        //newBuilding.transform.localScale (3.00, 2.00, 1.00)
        //this is new building posion its continuously change the posion of X and Y

        Debug.Log("newBuilding.transform.position " + newBuilding.transform.position);
        Debug.Log("new building local posion "+newBuilding.transform.localPosition.y);
        Debug.Log("building word posion "+newBuilding.transform.position.y);
       if(newBuilding.transform.position.y>0)
        {
            GameObject coin = Instantiate(coins, new Vector3(newBuilding.transform.position.x, newBuilding.transform.localPosition.y + 4f, 0), Quaternion.identity);
          //its genrate the coins 
        }
       





        building_list.Add(newBuilding);
       /* ySize = newBuilding.GetComponent<SpriteRenderer>().bounds.size.y;
        xSize = newBuilding.GetComponent<SpriteRenderer>().bounds.size.x;
        */
      //  coinGenretion();
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


    /* public void GenerateBuilding()
    {
        currentScale = GetRandomScale();

        // Set fixedPosition to 0 to ensure bottomPosition is always 0
        spawnPosition = new Vector3(player.transform.position.x + 15f, fixedPosition, 0);

        // Instantiate building with the current scale at the calculated position
        newBuilding = Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
        newBuilding.transform.localScale = new Vector2(currentScale.x, Mathf.Abs(currentScale.y)); // Ensure y-scale is positive
        topPosition = newBuilding.transform.position.y + newBuilding.GetComponent<SpriteRenderer>().bounds.extents.y;
        Debug.Log("Top Position of newBuilding: " + topPosition);

         xSize = newBuilding.GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log("X Size of newBuilding: " + xSize);

        coinGenretion();
        // Debug.Log("Position of object: " + newBuilding.transform.position + ", Scale: " + newBuilding.transform.localScale);
    }*/

    /* public void DestroyBuildings()
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

                }
            }
        }
    }*/
}


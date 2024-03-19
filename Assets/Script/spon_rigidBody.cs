using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class spon_rigidBody : MonoBehaviour
{
    [SerializeField] private GameObject rigidBodyPrefab;
    [SerializeField] private GameObject player;
    private float lastBuildingXPosition = -37f;
    private float distanceBetweenBuildings = 8f;
    private void Start()
    {       
            SpawnInitialrigidBodyPrefab();       
    }

    void Update()
    {
        DestroyrigidBodyPrefab();  
       
    } 

    void SpawnInitialrigidBodyPrefab()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnrigidBodyPrefab();

        }
    }

    void SpawnrigidBodyPrefab()
    {
        Vector2 spawnPosition = new Vector2(lastBuildingXPosition + distanceBetweenBuildings, 9f);
        Instantiate(rigidBodyPrefab, spawnPosition, Quaternion.identity);  
        lastBuildingXPosition = spawnPosition.x;      
    }

    public void DestroyrigidBodyPrefab()
    {
        // Check each building and destroy it if the player has crossed it and they are a certain distance apart
        GameObject[] rigidBodys = GameObject.FindGameObjectsWithTag("rigidBody");

        foreach (var rigidBody in rigidBodys)
        {
            if (player != null)
            {             

                if (rigidBody.transform.position.x < player.transform.position.x - 10f)
                {
                    Destroy(rigidBody);
                    SpawnrigidBodyPrefab();
                }
              
            }
        }
    }
}

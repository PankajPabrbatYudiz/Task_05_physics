using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovingScript : MonoBehaviour
{

    [SerializeField] private GameObject Ground;
    [SerializeField] private Transform player;
    [SerializeField] private float offsetx;
    private void Update()
    {
        movingGround();
    }
   private void movingGround()
    {
        if(Ground.transform.position.x<player.position.x-20f) 
        {
            Ground.transform.position = new Vector3(player.position.x,0,0) + new Vector3(10f,-4.30f,0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            Debug.Log("test");
            //  Application.LoadLevel("Youlose");
        }

    }
}

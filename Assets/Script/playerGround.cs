using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerGround : MonoBehaviour
{
    [SerializeField] private AudioSource dieSound;
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetY=0f;
    [SerializeField] private Canvas gameOver;
    [SerializeField] private Canvas playeingScrean;
    void Start()
    {
       movement();
    }

    
    void Update()
    {
        movement();
    }
    private void movement()
    {
        if (player != null)
        {
            
       
        if (transform.position.x<(player.transform.position.x-15f))
        {
            transform.position = new Vector3(player.transform.position.x+ 35f,offsetY,0 );
        }
        }
    }
    private bool gameover=false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
                             
           

            if (player!=null)
            {
                gameover = true;

             dieSound.Play();
            }
            displaygameOver();


        }

    }

   void displaygameOver()
    {
        if (gameover)
        {
            Debug.Log("hello this is playing ");
            gameOver.enabled = true;
            playeingScrean.enabled = false;
            gameover = false;
        }
    }
       
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    float score = 0;
 
    [SerializeField] private float OffsetForce;
    [SerializeField] private float speed;
    [SerializeField] private GameObject coins;
    public TextMeshProUGUI textvalue;
    [SerializeField] public Canvas startUI;
    [SerializeField] public Canvas playaGain;
    [SerializeField] public Canvas playingScrean;
    [SerializeField] public Canvas setting;
    [SerializeField] private bool istouch = true;

    /*  g




      [SerializeField] private float OffsetForce;
       [SerializeField] private float speed;
      // [SerializeField] private float maxUpwardVelocity;

       private void Start()
       {

       }

       private void Update()
       {
           if (Input.touchCount > 0)
           {

                       if (transform.position.y < 5f)
                       {
                           Vector2 jumpDirection = Vector2.up + Vector2.right * OffsetForce;
                           rb.AddForce(jumpDirection * speed, ForceMode2D.Impulse);
                       }



           }


           if (transform.position.y >= 5f)
           {

               rb.velocity = new Vector2(rb.velocity.x, 0f);
           }
       }




          j*/


    public bool isStart = false;
    private void Start()
    {
       
    }
    private void Update()

    {
       
       // Debug.Log("cURRETN GAME OBJECTR "+ EventSystem.current.currentSelectedGameObject);
       
        if (istouch)
        {


            if (isStart)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (EventSystem.current.IsPointerOverGameObject())
                        {
                            jump();
                        }
                        
                    }
                   
                        // Check if the mouse was clicked over a UI element
                        if (EventSystem.current.IsPointerOverGameObject())
                        {
                            Debug.Log("Clicked on the UI");
                        }
                    
                    if (transform.position.y >= 5.41f)
                    {

                        rb.velocity = new Vector2(rb.velocity.x, 0f);
                    }
                }
                /*if (transform.position.y >= 5.41f)
                {

                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                }*/
            }


        }
    }
    public void startGame()
    {
        Debug.Log("hello ");
       
        isStart = true;
        startUI.enabled = false;
        playingScrean.enabled = true;
          
        
    }
    public void gameReset()
    {
        //  transform.position=new Vector3 (-20f, 5.41f, 0f);
        Debug.Log("this is restar");
        startUI.enabled = true;
        playingScrean.enabled = false;
        playaGain.enabled=false;
        transform.position=new Vector3(-20f, 5.41f, 0);
        SceneManager.LoadScene("PlayingScene", LoadSceneMode.Single);

    }


    public void jump()
    {
                if (transform.position.y < 5.41f)
                        {
            Vector2 jumpDirection = Vector2.up + Vector2.right * OffsetForce;

            rb.AddForce(jumpDirection * speed, ForceMode2D.Impulse);
           

        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            
            Destroy(collision.gameObject);
            score = score + 10;


            textvalue.text = score.ToString();
            Debug.Log(score);
        }
    }
    /// <summary>
    /// Gracity Update
    /// </summary>
    public void gravityUpdate()
    {
        istouch = false;
        setting.enabled = true;
    }

    public void low()
    {
        Physics2D.gravity = new Vector2(0, -1.0F);
    }
 
    public void medium()
    {
        Physics2D.gravity = new Vector3(0, -5.0F);
    }
    public void high()
    {
        Physics2D.gravity = new Vector2(0, -10.0F);
    }
    public void save()
    {
        istouch = true;
        setting.enabled = false;
    }
}

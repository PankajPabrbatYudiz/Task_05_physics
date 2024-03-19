using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    [SerializeField] private AudioSource coinsSound;
    [SerializeField] private AudioSource backGroundSound;
    [SerializeField] private float OffsetForce;
    [SerializeField] private float speed;
    [SerializeField] private GameObject coins;
    [SerializeField] private Camera m_Camera;
    public TextMeshProUGUI textvalue;
    [SerializeField] public Canvas startUI;
    [SerializeField] public Canvas playaGain;
    [SerializeField] public Canvas playingScrean;
    [SerializeField] public Canvas setting;
    [SerializeField] private bool istouch = true;
    float cameraHeight;
    float cameraWidth;

    Vector2 upperLimit = new Vector2();
    Vector2 lowerLimit = new Vector2();
    float objectwidth;
    float objectheight;

    public bool isStart = false;

    private void Awake()
    {
        Application.targetFrameRate = 160;
    }
    private void Start()
    {


        float orthographicSize = m_Camera.orthographicSize;


        cameraHeight = orthographicSize * 2;
        cameraWidth = cameraHeight * m_Camera.aspect;
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.y;


    }
    private void Update()

    {
        if (gameManeger.Instance.isPlay)
        {

            upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
            Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y), 0);

            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {

                    jump();
                }
            }
        }
    }


    public void startGame()
    {
        isStart = true;
        startUI.enabled = false;
        playingScrean.enabled = true;
        backGroundSound.Play();

    }
    public void gameReset()
    {


        startUI.enabled = true;
        playingScrean.enabled = false;
        playaGain.enabled = false;
        transform.position = new Vector3(-20f, 5.41f, 0);
        SceneManager.LoadScene("level01", LoadSceneMode.Single);

    }


    public void jump()
    {
        Vector2 jumpDirection = new Vector2(0, 2) + Vector2.right * OffsetForce;
        rb.AddForce(jumpDirection * speed, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            score = score + 10;
            textvalue.text = score.ToString();
           coinsSound.Play();
        }

    }

    public void gravityUpdate()
    {
        istouch = false;
        setting.enabled = true;
    }

    public void low()
    {
        Physics2D.gravity = new Vector2(0, -4.0F);
    }

    public void medium()
    {
        Physics2D.gravity = new Vector3(0, -7.0F);
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

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class spiderManScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private DistanceJoint2D distanceJoint;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private Rigidbody2D rb;
    float speed = 3f;
    [SerializeField] private float targetAngle = 45f; // Define your desired angle here
    [SerializeField] private float rotationSpeed = 5f; // Adjust rotation speed as needed
    Vector2 direction = Vector2.zero;
    float angle = 0f;
    Vector2 boder = new Vector2(0, 0);
    Vector2 point = new Vector2();
    void Start()
    {
       // distanceJoint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManeger.Instance.isPlay)
        {

            point = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, transform.position.x, point.x), Mathf.Clamp(transform.position.y, transform.position.y, point.y), 0);


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                distanceJoint.distance -= 0.1f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                distanceJoint.distance += 0.1f;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                /* float horizontalInput = 0.9f;
                 player.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
          */
                float horizontalInput = 0.9f;
                player.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));

            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                float horizontalInput = 0.9f;
                player.transform.Translate(new Vector3(-horizontalInput * speed * Time.deltaTime, 0f, 0f));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                distanceJoint.connectedBody = null;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pointerPosition, Vector2.zero, layerMsk);
                if (hit.collider.TryGetComponent<DistanceJoint2D>(out DistanceJoint2D component))
                {
                    if (distanceJoint.connectedBody == null && hit.collider != null)
                    {
                        // Debug.Log("Raycast Hit");
                        distanceJoint = hit.collider.gameObject.GetComponent<DistanceJoint2D>();
                        distanceJoint.connectedBody = rb;

                    }
                }

            }



        }




    }
}

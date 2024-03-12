using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class camerafollow : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float xOffset;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothTime = 0.25f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {

            Vector3 targetPosition = new Vector3(transform.position.x, 0, 0) + offset;

            m_Camera.transform.position = Vector3.Lerp(new Vector3(transform.position.x + xOffset, 4.5f, 0), targetPosition, smoothTime);
                      
        }
    }



    

}

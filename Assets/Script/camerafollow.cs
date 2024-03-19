using System;
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
    [SerializeField] private GameObject player;
    [SerializeField] private float xOffset;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothTime = 0.25f;
    int instantIdOfobject = 0;
    int moveCamera = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("collider") )
        {
        
            Debug.Log("collision.gameObject.GetInstanceID() " + collision.gameObject.GetInstanceID());
            if ( instantIdOfobject!=collision.gameObject.GetInstanceID())
            {
                instantIdOfobject = collision.gameObject.GetInstanceID();
                
                StartCoroutine(MoveCamerea());
             
            }


        }
    }
   

    IEnumerator MoveCamerea()
    {
        float time = 0;
            Vector3 targetPosition = new Vector3(transform.position.x, 0, 0) + offset;
        Vector3 startPos = m_Camera.transform.position ;
        while (time<1)
        {
            time += 0.05f;
            m_Camera.transform.position = Vector3.Lerp(startPos, targetPosition, time);
            yield return null;
        }
    }
    

}

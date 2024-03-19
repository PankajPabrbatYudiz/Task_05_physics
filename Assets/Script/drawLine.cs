using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public static drawLine draw;
    [SerializeField] private LineRenderer lineRenderer;
    private GameObject connectedObject;
    private DistanceJoint2D distanceJoint;
    public bool isLineDraw = false;
    //[SerializeField] private float distanceBetweenTwoPoints = 0.1f;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        if (draw == null)
        {
            draw = this;
        }

      // lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        Debug.Log("connectedObject " + Vector2.zero);
       // Debug.Log("distanceJoint " + distanceJoint);
    }

    private void Update()
    {
        if (gameManeger.Instance.isPlay)
        {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // this take the posion from the camera local to world in vector 2D

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(pointerPosition, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent<DistanceJoint2D>(out DistanceJoint2D joint))
                    {
                        if (distanceJoint == null)
                        {
                            distanceJoint = joint;
                            connectedObject = hit.collider.gameObject;
                            DrawLineToConnectedObject();
                            source.Play();
                           // isLineDraw = true;
                        }
                        else
                        {
                            RemoveLine();
                          //  isLineDraw = false;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RemoveLine();
            }

            // this line update the starting posion of the line as the player posion 
            if (distanceJoint != null && connectedObject != null)
            {
                lineRenderer.SetPosition(0, transform.position);
            }
        }

    }

    private void DrawLineToConnectedObject()
    {

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, connectedObject.transform.position);
    }

    private void RemoveLine()
    {
        lineRenderer.positionCount = 0;
        if (distanceJoint != null)
        {
            distanceJoint.connectedBody = null;
            distanceJoint = null;
            connectedObject = null;
        }
    }
}

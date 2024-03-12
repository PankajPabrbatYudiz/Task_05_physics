using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBulding : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    private float time = 20f;
    private float tempalary;
    void Start()
    {
        Building();
    }

    // Update is called once per frame
    void Update()
    {
        //  Building();
        //  tempalary += Time.deltaTime;
        if (transform.position.x < Player.transform.position.x - 10)
        {
            Destroy(gameObject);
        }
      /*  transform.localScale = new Vector2(Random.Range(2, 10), Random.Range(6, 19));
        Debug.Log("Scale of Bulding " + transform.localScale);
        Debug.Log("position of building " + transform.position);*/
       
    }
    private void Building()
    {
        if (tempalary > time)
        {
           /* transform.localScale = new Vector2(Random.Range(2, 10), Random.Range(6, 19));
        Debug.Log("Scale of Bulding "+transform.localScale);
        Debug.Log("position of building "+transform.position);*/
        // transform.position = new Vector2(Player.transform.position.x+17f,0);
       // create();
       }
    }
    private void create()
    {
       // transform.localScale = new Vector2(Random.Range(2, 10), Random.Range(6, 19));
    }
}

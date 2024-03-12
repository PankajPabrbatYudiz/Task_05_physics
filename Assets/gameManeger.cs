using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManeger : MonoBehaviour
{
    public static gameManeger Instance;
    [SerializeField] public GameObject startUI;
    public bool isStart=false;
      public void  Update()
         {
         

         }
    public void startGame()
    {
        Debug.Log("hello ");
        isStart = true;
        startUI.SetActive(false);

    }
}

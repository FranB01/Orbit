using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    private GameControl gc;

    private void Start()
    {
        gc = FindObjectOfType<GameControl>();
    }


    public void GetCoin()
    {
        gc.GetCoin();
        
        Destroy(gameObject);
    }
}

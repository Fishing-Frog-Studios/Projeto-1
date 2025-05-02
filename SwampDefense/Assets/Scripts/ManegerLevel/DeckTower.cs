using UnityEngine;
using System.Collections.Generic;
using System;


public class DeckTower : MonoBehaviour
{
    public static DeckTower main;
   
    public GameObject[] towersDeck = new GameObject[6];

    private void Awake()
    {
        main = this;
    }
}


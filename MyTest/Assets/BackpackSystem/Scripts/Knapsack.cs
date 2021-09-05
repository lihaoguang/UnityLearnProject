using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : Inventory
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            int id = Random.Range(1, 4);
            Debug.Log(id);
            StoreItem(id);
        }
    }
}

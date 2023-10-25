using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Inventory : MonoBehaviour
{
    private List<(string item, int amount)> heldItems = new List<(string item, int amount)>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("key", StringComparison.CurrentCultureIgnoreCase))
        {
            Debug.Log("Key found");
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> heldItems = new Dictionary<string, int>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetBase().gameObject.name.Contains("key", StringComparison.CurrentCultureIgnoreCase))
        {
            //Debug.Log("Key found");
            heldItems.AddItem("Key");
            other.transform.GetBase().gameObject.SetActive(false);
        }

        if (other.transform.GetBase().gameObject.name.Contains("hatch", StringComparison.CurrentCultureIgnoreCase) && heldItems.RemoveItem("Key"))
        {
            // Open the hatch
        }
    }

}

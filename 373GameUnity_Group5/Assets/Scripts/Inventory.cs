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

        if (other.transform.GetBase().gameObject.name.Contains("hatch", StringComparison.CurrentCultureIgnoreCase))
        {
            Hatch hatch = other.transform.GetBase().gameObject.GetComponent<Hatch>();
            if (hatch == null || hatch.Open)
            {
                string message = hatch == null ? "Collided hatch does not have hatch script attached" : "Hatch is already open";
                Debug.LogError(message);
                return;
            }
            
            // Collided with hatch
            if (heldItems.RemoveItem("Key"))
            {
                hatch.Open = true;
            }
            else Debug.Log("Cannot open the hatch without a key");
        }
    }

}

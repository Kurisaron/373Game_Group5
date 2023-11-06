using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class Killer : MonoBehaviour
{
    private GameObject hatch;
    
    private void OnValidate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No rigidbody on the killer. Re-add it now.");
        }

        // Ensure the rigidbody has the appropriate constraints
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private async void Awake()
    {
        Transform hatchTransform = Array.Find(FindObjectsOfType<Transform>(), transform => transform.GetBase().gameObject.name.Contains("hatch", StringComparison.CurrentCultureIgnoreCase));
        if (hatchTransform == null)
        {
            Debug.LogError("No hatch found in scene, killer will not do anything");
            return;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetBase().gameObject == hatch)
        {
            CloseHatch();
        }
    }

    public void MoveKiller(Vector3 target)
    {
        GetComponent<NavMeshAgent>().destination = target;
    }

    private void CloseHatch()
    {

    }

    // AWAIT TASKS
    private async Task WaitForFixedGenerator()
    {
        if (FindObjectOfType<GeneratorFixer>() == null)
        {
            Debug.LogError("No generator fixer found");
            return;
        }
    }
}

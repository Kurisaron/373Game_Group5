using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class Killer : MonoBehaviour
{
    [SerializeField] private AudioClip screamClip;


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
        Hatch hatch = FindObjectOfType<Hatch>();
        if (hatch == null)
        {
            Debug.LogError("No hatch found");
            return;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        List<Transform> children = GetComponentsInChildren<Transform>().ToList();
        if (children.Contains(transform)) children.Remove(transform);
        foreach (Transform child in children)
        {
            child.gameObject.SetActive(false);
        }

        await WaitForFixedGenerator();

        foreach (Transform child in children)
        {
            child.gameObject.SetActive(true);
        }
        rb.useGravity = true;

        MoveKiller(hatch.transform.position);

        await WaitForClosedHatch(hatch);

        // Make the killer leave the view here
        Vector3 walkingDirection = -Camera.main.transform.right;
        MoveKiller(transform.position + (walkingDirection * 20.0f));

        await WaitForLeftView();

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetBase().gameObject.TryGetComponent(out Hatch temp))
        {
            CloseHatch(temp);
        }
    }

    public void MoveKiller(Vector3 target)
    {
        GetComponent<NavMeshAgent>().destination = target;
    }

    private void CloseHatch(Hatch target)
    {
        target.Open = false;
    }

    // AWAIT TASKS
    private async Task WaitForFixedGenerator()
    {
        Generator generator = FindObjectOfType<Generator>();
        if (generator == null)
        {
            Debug.LogError("No generator found");
            return;
        }

        while (!generator.Status.isFixed)
        {
            await Task.Yield();
        }

        await Task.Delay(1000);

        AudioSource screamSource = new GameObject("Scream").AddComponent<AudioSource>();
        if (screamClip != null)
        {
            screamSource.clip = screamClip;
            screamSource.Play();
        }
        else Debug.LogWarning("SCREAM!");

        while (screamSource != null && screamSource.isPlaying)
        {
            await Task.Yield();
        }

        if (screamSource != null) Destroy(screamSource.gameObject);
    }

    private async Task WaitForClosedHatch(Hatch hatch)
    {
        while (hatch.Open)
        {
            await Task.Yield();
        }

    }

    private async Task WaitForLeftView()
    {
        while (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), GetComponentInChildren<Collider>().bounds))
        {
            await Task.Yield();
        }
    }
}

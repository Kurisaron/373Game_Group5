using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTester : MonoBehaviour
{
    [SerializeField] private Killer killer;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveKiller();
        }
    }

    private void MoveKiller()
    {
        Vector3 target;
        if (!Utils.MouseRaycast(out target))
        {
            target = Utils.MouseToHorizonCoordinates();
        }

        killer.MoveKiller(target);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static bool MouseRaycast(out Vector3 point)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
        {
            point = hit.point;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    public static Vector3 MouseToHorizonCoordinates()
    {
        Vector3 direction = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float magnitude = (0.0f - mousePos.y) / direction.y;
        float x = (magnitude * direction.x) + mousePos.x;
        float z = (magnitude + direction.z) + mousePos.z;
        return new Vector3(x, 0.0f, z);
    }
}

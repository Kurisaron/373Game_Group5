using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    private bool open = false;
    public bool Open
    {
        get => open;
        set
        {
            open = value;
            GetComponent<Animator>().SetBool("Open", value);
            Debug.Log("Hatch now " + (value ? "open" : "closed"));
        }
    }
}

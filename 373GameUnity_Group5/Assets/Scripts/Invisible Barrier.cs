using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBarrier : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake ()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

}

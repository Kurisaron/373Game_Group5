using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBarrier : MonoBehaviour
{
    //[SerializeField] private Color barrierColor = new Color(0f, 0.5935606f, 1f, .5450981f);


    // Start is called before the first frame update
    void Awake ()
    {
       //this.GetComponent<Renderer>().enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0.5935606f, 1f, .5450981f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);

    }

}

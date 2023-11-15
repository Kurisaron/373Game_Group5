using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowsCircle : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector3 wireCube = new Vector3(1, 10, 1);

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 1f * Time.deltaTime * speed, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.transform.position, wireCube);


        /*foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);*/
    }
}

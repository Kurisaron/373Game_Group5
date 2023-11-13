using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGenFix : MonoBehaviour
{

    [SerializeField] private GameObject lights;
    [SerializeField] private List<Animator> pistons = new List<Animator>();
    [SerializeField] private float pistonDiff = 0.5f;
    


    // Start is called before the first frame update
    void Awake()
    {
        lights.SetActive(false);
        foreach (Animator anim in pistons)
        {
            anim.enabled = false;
        }
    }


    public void onGenFix()
    {
        lights.SetActive(true);
        pistons[0 ].enabled = true;
        pistons[4].enabled = true;
        StartCoroutine(PistonPair());
    }

    IEnumerator PistonPair()
    {
        yield return new WaitForSeconds(pistonDiff);
        pistons[1].enabled = true;
        pistons[5].enabled = true;

        yield return new WaitForSeconds(pistonDiff);
        pistons[2].enabled = true;
        pistons[6].enabled = true;

        yield return new WaitForSeconds(pistonDiff);
        pistons[3].enabled = true;
        pistons[7].enabled = true;
    }

}

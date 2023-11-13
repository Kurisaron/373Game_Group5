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
        
        StartCoroutine(lightsOn());

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

    IEnumerator lightsOn()
    {
        lights.SetActive(true);
        yield return new WaitForSeconds(.01f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.05f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.02f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.05f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.03f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.05f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.01f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.05f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.1f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.15f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.2f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.3f);
        lights.SetActive(true);
        yield return new WaitForSeconds(.7f);
        lights.SetActive(false);
        yield return new WaitForSeconds(.8f);
        lights.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowTimer : MonoBehaviour
{

    [SerializeField] private Animator crowSide1;
    [SerializeField] private Animator crowSide2;
    private float animationTimer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAnimation());

    }


    IEnumerator playAnimation()
    {
        animationTimer = Random.Range(2f, 3f);
        //print(animationTimer);
        yield return new WaitForSeconds(animationTimer);
        /*crowSide1.Play("crowSide1");
        crowSide2.Play("crowSide2");*/
        crowSide1.SetBool("Flap", true);
        crowSide2.SetBool("Flap", true);
        //print("true");

        yield return new WaitForSeconds(2f);
        crowSide1.SetBool("Flap", false);
        crowSide2.SetBool("Flap", false);
        //print("false");

        StartCoroutine(playAnimation());
    }
}

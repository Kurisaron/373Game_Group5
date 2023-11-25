using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class fogManaer : MonoBehaviour
{

    [SerializeField] VisualEffect fogVisualEffect;
    [SerializeField] VisualEffect fogVisualEffectLine;
    [SerializeField] VisualEffect fogVisualEffectLine2;

    [SerializeField] float staterFogTimer = 10f;
    float fogReducer = 0f;
    private bool delay = false;

    [Range(0f, 200f)]
    [SerializeField] private float playRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(starterFogMaker());
        StartCoroutine(checkDelay());


        StartCoroutine(fogLineRateChange());

    }


    void Update()
    {
        fogVisualEffectLine.playRate = playRate;
        fogVisualEffectLine2.playRate = playRate;

        //print("Particle Count: " + fogVisualEffect.aliveParticleCount);
        if (fogVisualEffect.aliveParticleCount == 0 && delay)
        {
            fogVisualEffect.enabled = false;
        }
    }

    IEnumerator starterFogMaker()
    {
        yield return new WaitForSeconds(staterFogTimer);
        //fogVisualEffect.pause = true;
        //print("Spawn Rate: 0");
        fogVisualEffect.SetFloat("Spawn Rate", fogReducer);

    }

    IEnumerator checkDelay()
    {
        yield return new WaitForSeconds(2f);
        delay = true;
    }


    IEnumerator fogLineRateChange()
    {
        yield return new WaitForSeconds(3f);
        playRate = 1f;
    }

}

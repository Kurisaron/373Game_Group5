using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class GeneratorFixer : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;
    private (bool isFixed, bool isNear, Coroutine fixRoutine) generator;
    private (bool isFixed, bool isNear, Coroutine fixRoutine) Generator
    {
        get => generator;
        set
        {
            generator = value;

            UpdateProgressBar();
            if (!generator.isFixed && generator.isNear && generator.fixRoutine == null) generator.fixRoutine = StartCoroutine(FixRoutine());
        }
    }

    private void Awake()
    {
        Generator = (false, false, null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetBase().gameObject.name.Contains("generator", StringComparison.CurrentCultureIgnoreCase))
        {
            Generator = (Generator.isFixed, true, Generator.fixRoutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetBase().gameObject.name.Contains("generator", StringComparison.CurrentCultureIgnoreCase))
        {
            Generator = (Generator.isFixed, false, Generator.fixRoutine);
        }
    }

    private IEnumerator FixRoutine()
    {
        Debug.Log("Fix routine started");
        float fixProgress = 0.0f; // 0 = 0%, 1 = 100%
        UpdateProgressBar();
        
        while (Generator.isNear)
        {
            yield return null;
            fixProgress += Time.deltaTime / 10f;
            UpdateProgressBar(fixProgress);
            Debug.Log("Fix progress at " + (fixProgress * 100.0f).ToString() + " percent");
            if (fixProgress >= 1.0f) goto GeneratorFixed;
        }

        Generator = (Generator.isFixed, Generator.isNear, null);
        Debug.Log("Fix routine ended, moved too far away");
        yield break;

        GeneratorFixed:
        Debug.Log("Fix routine completed");
        Generator = (true, Generator.isNear, null);
    }

    private void UpdateProgressBar(float value = 0)
    {
        progressSlider.gameObject.SetActive(Generator.isNear);

        progressSlider.value = value;
    }
}

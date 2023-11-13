using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider), typeof(AudioSource))]
public class Generator : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;
    private (bool isFixed, bool playerNear, Coroutine fixRoutine) status;
    public (bool isFixed, bool playerNear, Coroutine fixRoutine) Status
    {
        get => status;
        private set
        {
            status = value;

            UpdateProgressBar();
            if (!status.isFixed && status.playerNear && status.fixRoutine == null) status.fixRoutine = StartCoroutine(FixRoutine());
        }
    }


    private void OnValidate()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider == null) return;

        collider.isTrigger = true;
    }

    private void Awake()
    {
        Status = (false, false, null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetBase().gameObject.tag == "Player")
        {
            Status = (Status.isFixed, true, Status.fixRoutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetBase().gameObject.tag == "Player")
        {
            Status = (Status.isFixed, false, Status.fixRoutine);
        }
    }

    private IEnumerator FixRoutine()
    {
        Debug.Log("Fix routine started");
        float fixProgress = 0.0f; // 0 = 0%, 1 = 100%
        UpdateProgressBar();

        while (Status.playerNear)
        {
            yield return null;
            fixProgress += Time.deltaTime / 5f;
            UpdateProgressBar(fixProgress);
            Debug.Log("Fix progress at " + (fixProgress * 100.0f).ToString() + " percent");
            if (fixProgress >= 1.0f) goto GeneratorFixed;
        }

        Status = (Status.isFixed, Status.playerNear, null);
        Debug.Log("Fix routine ended, moved too far away");
        yield break;

        GeneratorFixed:
        Debug.Log("Fix routine completed");
        Status = (true, Status.playerNear, null);
    }

    private void UpdateProgressBar(float value = 0)
    {
        progressSlider.gameObject.SetActive(Status.playerNear && !Status.isFixed);

        progressSlider.value = value;
    }
}

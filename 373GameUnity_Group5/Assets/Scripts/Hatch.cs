using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Hatch : MonoBehaviour
{
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    
    private bool open = true;
    public bool Open
    {
        get => open;
        set
        {
            open = value;
            AnimateHatch(value);
            PlayHatchSound(value);

            Debug.Log("Hatch now " + (value ? "open" : "closed"));
        }
    }

    private void AnimateHatch(bool open) => GetComponent<Animator>().SetBool("Open", open);

    private void PlayHatchSound(bool open)
    {
        AudioSource hatchSource = GetComponent<AudioSource>();
        if (hatchSource.isPlaying) hatchSource.Stop();
        hatchSource.clip = open ? openSound : closeSound;
        hatchSource.Play();
    }
}

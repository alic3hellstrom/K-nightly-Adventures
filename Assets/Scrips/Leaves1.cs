using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves1 : MonoBehaviour
{
    [SerializeField] private AudioClip[] leaveClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isPlaying = audioSource.isPlaying;
        if (!isPlaying)
        {
            int rnd = UnityEngine.Random.Range(0, leaveClips.Length);
            audioSource.clip = leaveClips[rnd];
            audioSource.Play();
        }
    }
}
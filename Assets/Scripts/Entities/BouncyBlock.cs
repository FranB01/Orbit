using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBlock : MonoBehaviour
{
    public bool vertical; // direction of bounce (true = is on the floor or ceiling and bounces accordingly)
    private AudioSource audioSource;
    [SerializeField] private AudioClip bounceClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Bounce()
    {
        audioSource.PlayOneShot(bounceClip);
    }
}

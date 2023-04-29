using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip laserSfx;
    [SerializeField] AudioClip engineSfx;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLaser()
    {
        audioSource.PlayOneShot(laserSfx, 0.4f);
    }

    public void PlayEngine()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}

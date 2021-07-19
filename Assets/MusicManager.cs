using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Play(audioClip);
    }

    public void Play(AudioClip musicToPlay)
    {
        audioSource.clip = musicToPlay;
        audioSource.Play();
    }
}

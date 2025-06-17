using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource Music;

    private void Start()
    {
        Music.Play();
    }
    public void StopMusic() 
    {
        Music.Stop();
    }
}
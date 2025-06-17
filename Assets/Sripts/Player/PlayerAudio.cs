using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource TankFire;

    [SerializeField]
    private AudioSource Boom;

    public void TankShoots()
    {
        TankFire.Play();
    }
    public void SetIsThePlayerAlive(bool alive)
    {
        if (alive==false) 
        {
            Boom.Play();
        } 
    }
}
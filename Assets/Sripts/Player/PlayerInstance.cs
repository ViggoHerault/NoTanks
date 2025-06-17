using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerInstance : MonoBehaviour
{
    [SerializeField]
    private int playerCount = 0;
    public int TotalOfPlayers = 0;


    //infos -> scripts
    void Start()
    {
        this.GetComponent<PlayerShoot>().SetNumberOfPlayer(playerCount);
        this.GetComponent<PlayerSetColor>().SetNumberOfPlayer(playerCount);

        this.GetComponent<PlayerUI>().SetNumberOfPlayer(playerCount);
        this.GetComponent<PlayerUI>().SetTotalOfPlayers(TotalOfPlayers);
    }


    //getter et setter
    public void SetNumberOfPlayer(int number)
    {
        playerCount = number;
    }
    public int GetNumberOfPlayer()
    {
        return playerCount;
    }


    //changements 
    public void ChangeLifeState(bool b)
    {
        this.GetComponent<PlayerMovements>().SetIsThePlayerAlive(b);
        this.GetComponent<PlayerShoot>().SetIsThePlayerAlive(b);
        this.GetComponent<PlayerAudio>().SetIsThePlayerAlive(b);
    }
    public void ChangeRenderers(bool b) 
    {
        this.GetComponent<PlayerSetColor>().SetRenderers(b);
    }
    public void ChangeUi(string s) 
    {
        this.GetComponent<PlayerUI>().UiWhenOnePlayerIsDead(s);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private int playerCount = 0;
    private int TotalOfPlayers = 0;

    private GameObject killFeed;
    private GameObject winScreen;
    private GameObject bars;

    public void SetNumberOfPlayer(int number)
    {
        playerCount = number;
    }
    public void SetTotalOfPlayers(int number)
    {
        TotalOfPlayers = number;
    }


    void Start()
    {
        killFeed = GameObject.Find("Kill feed");

        winScreen = GameObject.Find("Win Screen");
        winScreen.GetComponent<WinScreen>().SetupNumberOfTanks(TotalOfPlayers);

        bars = GameObject.Find("Bars");
    }

    public void UiWhenOnePlayerIsDead(string name) 
    {
        killFeed.GetComponent<KillFeed>().DisplayKillFeed(name, playerCount);
        winScreen.GetComponent<WinScreen>().OneTankEliminated(playerCount);
        bars.GetComponent<Bars>().OneTankEliminated(playerCount);
    }
}
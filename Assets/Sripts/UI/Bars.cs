using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> slideBarPlayers;
    [SerializeField]
    private List<GameObject> tanks;

    private int numberOfPlayers;

    public void FindTanks(int totalofplayer)
    {
        numberOfPlayers = totalofplayer;

        foreach (GameObject tankPlayer in GameObject.FindGameObjectsWithTag("Player"))
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                slideBarPlayers[i].SetActive(true);

                if (tankPlayer.GetComponent<PlayerInstance>().GetNumberOfPlayer() == i)
                {
                    tanks[i] = tankPlayer;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            slideBarPlayers[i].transform.position = new Vector3(tanks[i].transform.position.x, 5, tanks[i].transform.position.z + 5);
        }
    }

    public void OneTankEliminated(int idTank) 
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (i== idTank) 
            {
                slideBarPlayers[i].SetActive(false);
            }
        }
    }
}
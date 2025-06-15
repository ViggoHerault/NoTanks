using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationsReceiver : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;

    void Awake()
    {
        int receivedValue = SceneInformations.Instance.numberOfPlayers;
        //Debug.Log(receivedValue);

        for (int i = 0; i < 3; i++)
        {
            if (receivedValue == i+2)//2 players minimum
            {
                spawner.SetAmountOfPlayers(i+2);
            }
        }
    }
}
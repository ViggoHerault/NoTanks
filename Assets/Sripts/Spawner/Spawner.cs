using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tankPrefab;

    [SerializeField]
    private int numberOfPlayers;

    [SerializeField]
    private List<Vector3> Positions;
    [SerializeField]
    private List<Vector3> Rotations;
    [SerializeField]
    private List<string> Maps;

    [SerializeField]
    private GameObject Bars;

    void Start()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject Player;

            Quaternion rotation = Quaternion.Euler(Rotations[i]);
            Player = Instantiate(tankPrefab, Positions[i], rotation);

            Player.GetComponent<PlayerInstance>().SetNumberOfPlayer(i);
            Player.GetComponent<PlayerInput>().SwitchCurrentActionMap(Maps[i]);
            Player.GetComponent<PlayerInstance>().TotalOfPlayers = numberOfPlayers;
        }

        Bars.GetComponent<Bars>().FindTanks(numberOfPlayers);
    }

    public void SetAmountOfPlayers(int amount) 
    {
        numberOfPlayers=amount;
    }
}
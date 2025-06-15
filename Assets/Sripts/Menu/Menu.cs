using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private PlayerInput MenuInput;

    public void OnTwoPlayers()
    {
        LoadScene(2);
    }
    public void OnTreePlayers()
    {
        LoadScene(3);
    }
    public void OnFourPlayers()
    {
        LoadScene(4);
    }


    public void LoadScene(int amountOfPlayers)
    {
        SceneInformations.Instance.numberOfPlayers = amountOfPlayers;
        SceneManager.LoadScene("Level");
    }
}
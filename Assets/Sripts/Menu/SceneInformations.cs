using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInformations : MonoBehaviour
{
    public static SceneInformations Instance;

    public int numberOfPlayers; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
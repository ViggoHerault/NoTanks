using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetColor : MonoBehaviour
{
    private int playerCount = 0;

    [SerializeField]
    private List<Color> Colors;
    [SerializeField]
    private List<Renderer> Renderers;

    public void SetNumberOfPlayer(int number)
    {
        playerCount = number;
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Renderers[i].material.SetColor("_Color", Colors[playerCount]);
        }
    }

    public Color GetTheColor()
    {
        return Colors[playerCount];
    }

    public void SetRenderers(bool b)
    {
        for (int i = 0; i < 4; i++)
        {
            Renderers[i].enabled = b;
        }
    }
}
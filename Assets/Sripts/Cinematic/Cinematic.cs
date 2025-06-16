using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> squares;
    [SerializeField]
    private List<GameObject> rectangles;
    [SerializeField]
    private List<GameObject> lines;
    [SerializeField]
    private GameObject loadingScreen;

    private int TotalOfPlayers = 0;

    void Awake()
    {
        TotalOfPlayers = SceneInformations.Instance.numberOfPlayers;
    }
    void Start()
    {
        StartCoroutine(CinematicTime());
    }

    private IEnumerator CinematicTime()
    {
        yield return new WaitForSeconds(1f);

        if(TotalOfPlayers == 2) 
        {
            rectangles[0].SetActive(true);
            rectangles[1].SetActive(true);

            lines[1].SetActive(true);
        }

        if (TotalOfPlayers == 3)
        {
            rectangles[0].SetActive(true);
            squares[4].SetActive(true);
            squares[5].SetActive(true);

            lines[1].SetActive(true);
            lines[2].SetActive(true);
        }

        if (TotalOfPlayers == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                squares[i].SetActive(true);
            }

            lines[0].SetActive(true);
            lines[1].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        loadingScreen.SetActive(false);

        yield return new WaitForSeconds(6.2f);
        SceneManager.LoadScene("Level");
    }
}
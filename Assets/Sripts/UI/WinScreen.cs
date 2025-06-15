using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Tanks;
    [SerializeField]
    private GameObject winnerText;

    [SerializeField]
    private List<bool> tanksAlive;

    public int TotalOfTanksInStart = 0;
    public int TotalOfTanksAlive = 0;

    public void SetupNumberOfTanks(int number) 
    {
        TotalOfTanksInStart = number;
        TotalOfTanksAlive = number;
    }

    public void OneTankEliminated(int loser) 
    {
        tanksAlive[loser] = false;
        TotalOfTanksAlive -= 1;
    }

    public void Update()
    {
        if (TotalOfTanksAlive==1) 
        {
            for (int i = 0; i < TotalOfTanksInStart; i++)
            {
                if (tanksAlive[i]==true) 
                {
                    winnerText.SetActive(true);
                    Tanks[i].SetActive(true);
                    StartCoroutine(ReturnToMenu());
                }
            }
        }
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }

}
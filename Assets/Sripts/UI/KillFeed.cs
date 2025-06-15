using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillFeed : MonoBehaviour
{
    //1st Kill
    [SerializeField]
    private List<GameObject> FirstTanks1;
    [SerializeField]
    private List<GameObject> FirstTanks2;
    [SerializeField]
    private GameObject firstTextKiller;

    //2nd Kill
    [SerializeField]
    private List<GameObject> SecondTanks1;
    [SerializeField]
    private List<GameObject> SecondTanks2;
    [SerializeField]
    private GameObject secondTextKiller;

    //3dr Kill
    [SerializeField]
    private List<GameObject> ThirdTanks1;
    [SerializeField]
    private List<GameObject> ThirdTanks2;
    [SerializeField]
    private GameObject thirdTextKiller;

    private int killCount = 0;

    private int killerTank;

    public void DisplayKillFeed(string winnerbullet, int Losertank)
    {
        if (winnerbullet == "Bullet01") 
        {
            killerTank = 0;
        }
        if (winnerbullet == "Bullet02")
        {
            killerTank = 1;
        }
        if (winnerbullet == "Bullet03")
        {
            killerTank = 2;
        }
        if (winnerbullet == "Bullet04")
        {
            killerTank = 3;
        }

        if (killCount==0) 
        {
            StartCoroutine(FirstKillFeedTime(killerTank, Losertank));
            
        }
        else if (killCount==1) 
        {
            StartCoroutine(SecondtKillFeedTime(killerTank, Losertank));
        }
        else
        {
            StartCoroutine(ThirdKillFeedTime(killerTank, Losertank));
        }
    }



    private IEnumerator FirstKillFeedTime(int winnertank, int deadtank) 
    {
        killCount += 1;

        firstTextKiller.SetActive(true);
        FirstTanks1[winnertank].SetActive(true);

        FirstTanks2[deadtank].SetActive(true);

        yield return new WaitForSeconds(2);

        firstTextKiller.SetActive(false);
        FirstTanks1[winnertank].SetActive(false);
        FirstTanks2[deadtank].SetActive(false);

        killCount -= 1;
    }

    private IEnumerator SecondtKillFeedTime(int winnertank, int deadtank)
    {
        killCount += 1;

        secondTextKiller.SetActive(true);
        SecondTanks1[winnertank].SetActive(true);
        SecondTanks2[deadtank].SetActive(true);

        yield return new WaitForSeconds(2);

        secondTextKiller.SetActive(false);
        SecondTanks1[winnertank].SetActive(false);
        SecondTanks2[deadtank].SetActive(false);

        killCount -= 1;
    }

    private IEnumerator ThirdKillFeedTime(int winnertank, int deadtank)
    {
        killCount += 1;

        thirdTextKiller.SetActive(true);
        ThirdTanks1[winnertank].SetActive(true);
        ThirdTanks2[deadtank].SetActive(true);

        yield return new WaitForSeconds(2);

        thirdTextKiller.SetActive(false);
        ThirdTanks1[winnertank].SetActive(false);
        ThirdTanks2[deadtank].SetActive(false);

        killCount -= 1;
    }
}
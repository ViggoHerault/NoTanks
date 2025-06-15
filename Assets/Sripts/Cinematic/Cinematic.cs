using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CinematicTime());
    }

    private IEnumerator CinematicTime()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level");
    }
}
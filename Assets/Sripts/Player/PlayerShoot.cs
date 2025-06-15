using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool isAlive = true;
    private int playerCount = 0;

    [SerializeField] 
    private GameObject BulletPrefab; 
    [SerializeField] 
    private GameObject ShootPoint; 
    [SerializeField] 
    private GameObject BoomPoint;
    [SerializeField]
    private GameObject explosion;

    private bool iShooting = false;
    private BarsFill bf;

    private void Start()
    {
        var Bars = GameObject.FindGameObjectsWithTag("Bars");
        foreach (var gameObject in Bars)
        {
            var barsfill = gameObject.GetComponent<BarsFill>();
            if (barsfill.matchingPlayer == playerCount)
            {
                bf = barsfill;
                break;
            }
        }
        StartCoroutine(BarsFillTime());
    }

    public void SetIsThePlayerAlive(bool alive)
    {
        isAlive = alive;
    }
    public void SetNumberOfPlayer(int number)
    {
        playerCount = number;
    }

    public void OnShoot()
    {
        if (iShooting == false && isAlive == true)
        {
            StartCoroutine(ShootTime(1f));
        }
    }

    private IEnumerator ShootTime(float delay)
    {
        iShooting = true;
        //bf.sliderValue = 0f;

        GameObject Bullet;
        Quaternion rotation = ShootPoint.transform.rotation;
        Bullet = Instantiate(BulletPrefab, new Vector3(ShootPoint.transform.position.x, 2.5f, ShootPoint.transform.position.z), rotation);
        Bullet.GetComponent<Bullet>().SetNumberOfBullet(playerCount);

        GameObject BigBoom;
        Quaternion BigBoomrotation = BoomPoint.transform.rotation;
        BigBoom = Instantiate(explosion, new Vector3(BoomPoint.transform.position.x, BoomPoint.transform.position.y, BoomPoint.transform.position.z), rotation);

        StartCoroutine(BarsFillTime());
        yield return new WaitForSeconds(delay);
        iShooting = false;
    }

    private IEnumerator BarsFillTime() 
    {
        bf.sliderValue = 0f;
        float elapsed = 0f;
        while (elapsed < 1)
        {
            elapsed += Time.deltaTime;
            bf.sliderValue = Mathf.Clamp01(elapsed / 1);
            yield return null;
        }
        bf.sliderValue = 1f;
    }
}
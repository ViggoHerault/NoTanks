using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCinematic : MonoBehaviour
{
    public int playerCount = 0;

    //SetColor
    [SerializeField]
    private List<Color> Colors;
    [SerializeField]
    private List<Renderer> Renderers;

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            Renderers[i].material.SetColor("_Color", Colors[playerCount]);
        }
    }

    //Collision
    private bool isAlive = true;
    [SerializeField]
    private Collider colliderTank;
    [SerializeField]
    private GameObject deadtank;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet01") | collision.gameObject.CompareTag("Bullet02") | collision.gameObject.CompareTag("Bullet03") | collision.gameObject.CompareTag("Bullet04")) 
        {
            if (isAlive == true)
            {
                deadtank.SetActive(true);
                deadtank.GetComponent<MeshRenderer>().material.SetColor("_Color", Colors[playerCount]);

                colliderTank.enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    Renderers[i].enabled = false;
                }

                isAlive = false;
            }
        }
    }

    //Shoot
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private GameObject ShootPoint;
    [SerializeField]
    private GameObject BoomPoint;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject bar;
    private BarsFill bf;

    private bool iShooting = false;

    void Start()
    {
        bf = bar.GetComponent<BarsFill>();
        StartCoroutine(BarsFillTime());
    }
    public void Shoot()
    {
        if (iShooting == false && isAlive == true)
        {
            StartCoroutine(ShootTime(1f));
        }
    }
    private IEnumerator ShootTime(float delay)
    {
        iShooting = true;

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

    //UI
    [SerializeField]
    private List<GameObject> Buttons;
    [SerializeField]
    private GameObject ShootButton;

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
    private void Update()
    {
        if (isAlive==false) 
        {
            bar.SetActive(false);
        }
    }
    public void SwitchButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].SetActive(false);
        }
        ShootButton.SetActive(true);
    }
}
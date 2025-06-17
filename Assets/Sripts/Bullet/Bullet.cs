using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 40f;
    [SerializeField]
    private Rigidbody rb;

    private Vector3 direction = Vector3.zero;

    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private GameObject explosionObject;

    [SerializeField]
    private List<Color> Colors;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    private BoxCollider colliderBullet;

    private bool notTouched = true;

    private int BulletCount = 0;

    [SerializeField]
    private AudioSource BulletExplosion;

    public void SetNumberOfBullet(int number)
    {
        BulletCount = number;
    }

    private void Start()
    {
        direction = transform.forward;
        meshRenderer.material.SetColor("_Color", Colors[BulletCount]);

        gameObject.tag = "Bullet0"+ (BulletCount+1);
    }

    private void FixedUpdate()
    {
        if (notTouched==true) 
        {
            rb.velocity = direction * bulletSpeed;
        }
        else 
        {
            meshRenderer.enabled = false;
            colliderBullet.enabled = false;
            rb.velocity = Vector3.zero;

            StartCoroutine(DestroyAfterTime(0.8f));
        }
    }
    private IEnumerator DestroyAfterTime(float delay) 
    {
        explosionObject.SetActive(true);
        explosion.Play();
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") | collision.gameObject.CompareTag("Player"))
        {
            notTouched = false;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            BulletExplosion.Play();
        }
    }
}
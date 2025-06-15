using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
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
                ThePlayerIsDead();
                DeadTankSetOn();
                RenderersAndColliderSetOff();
                DeadUiSetOn(collision.gameObject.tag);
            }
        }
    }

    private void ThePlayerIsDead() 
    {
        isAlive = false;
        this.GetComponent<PlayerInstance>().ChangeLifeState(false);
    }
    private void DeadTankSetOn() 
    {
        deadtank.SetActive(true);
        deadtank.GetComponent<MeshRenderer>().material.SetColor("_Color", GetComponent<PlayerSetColor>().GetTheColor());
    }
    private void RenderersAndColliderSetOff() 
    {
        this.GetComponent<PlayerInstance>().ChangeRenderers(false);
        colliderTank.enabled = false;
    }
    private void DeadUiSetOn(string name) 
    {
        this.GetComponent<PlayerInstance>().ChangeUi(name);
    }
}
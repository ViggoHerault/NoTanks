using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    private bool isAlive = true;

    [SerializeField]
    private PlayerInput playerMovements;
    [SerializeField]
    private Rigidbody rb;

    private Vector2 moveDirection = Vector2.zero;
    private float speed = 20f;


    public void SetIsThePlayerAlive(bool alive)
    {
        isAlive = alive;
    }

    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (isAlive == true)
        {
            rb.velocity = new Vector3(moveDirection.x * speed, 0, moveDirection.y * speed);

            if (moveDirection != Vector2.zero)
            {
                float smooth = 20.0f;

                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.y));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
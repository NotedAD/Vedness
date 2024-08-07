using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb2;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        movement.y = Input.GetAxis("Vertical") * moveSpeed;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

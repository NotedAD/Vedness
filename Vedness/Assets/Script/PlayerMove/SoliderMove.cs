using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMove : MonoBehaviour
{
    public float dirX, dirY;
    public bool isf = true;
    public float speed;

    private Rigidbody2D rb;
    private Animator anin;
    public Joystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        //управление и движение
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;

        anin.SetFloat("Horizontal", dirX);
        anin.SetFloat("Vertical", dirY);
        anin.SetFloat("Speed", speed);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void Flip()
    {
        isf = !isf;
        transform.Rotate(0f, 180, 0f);
    }
}

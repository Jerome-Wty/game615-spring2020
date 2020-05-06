using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField]
    private float runSpeed = 60f;

    [SerializeField]
    private float m_JumpForce = 60f;

    private float horizontalMove = 0f;

    private bool jump = false;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, runSpeed, jump, m_JumpForce);
        jump = false;
    }
}

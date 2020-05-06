using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    [SerializeField]
    private float runSpeed = 30f;

    [SerializeField]
    private float m_JumpForce = 60f;

    public PlayerType playerType;

    public Transform m_GroundCheck;

    public LayerMask m_GroundLayer;

    private Animator m_Animator;

    private float horizontalMove = 0f;

    private bool jump = false;

    private float speedUnit = 10f;

    private int jumpCount = 2;

    //private bool canSecondJump = false;

    //private bool m_Grounded = false;

    const float k_GroundedRadius = 0.3f;

    private bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if this is the player to play
        if (playerType == GameManager._instance.curPlayerType)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            m_Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime, runSpeed, jump, m_JumpForce);
        jump = false;
    }




    public void Move(float move, float runSpeed, bool jump, float jumpForce)
    {
        Vector3 targetVelocity = new Vector2(move * speedUnit * runSpeed, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = targetVelocity;

        if (jump)
        {
            if (GroundCheck())
            {
                jumpCount = 2;
            }
            if (GroundCheck() || jumpCount > 0)
            {

                m_Rigidbody2D.AddForce(new Vector2(0f, speedUnit * jumpForce));
                jumpCount -= 1;
                SoundManager._instance.PlayerJumpSound();
            }
        }

    }

    public bool GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_GroundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                // m_Grounded = true;
                return true;
            }
        }
        return false;
    }

    public void DestoryCharacter()
    {
        if (GameManager._instance.CurPlayer == this)
        {
            GameManager._instance.UpdateLiveAndUI(GameManager._instance.GetCurplayerLive() - 1);
            GameManager._instance.CurPlayer = null;
            Destroy(gameObject);
        }
    }

    public void DestoryCharacterPure()
    {

        if (GameManager._instance.CurPlayer == this)
        {
            GameManager._instance.CurPlayer = null;
            Destroy(gameObject);
        }

    }
}

public enum PlayerType
{
    A,
    B
}


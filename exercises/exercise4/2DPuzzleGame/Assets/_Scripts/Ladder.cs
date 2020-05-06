using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : ReactiveObj
{
    public float moveSpeed = 5f;

    private float speedMultiplier = 100f;

    public Transform respwanTopPos;
    public Transform respwanBotPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        m_rigidbody.velocity = GetDirVec() * Time.fixedDeltaTime * moveSpeed * speedMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestoryLine")
        {
            RespawnPos();
        }
    }

    public void RespawnPos()
    {
        if (moveDirection == Direction.Up)
        {
            transform.position = new Vector2(transform.position.x, respwanBotPos.position.y);
        }
        if (moveDirection == Direction.Down)
        {
            transform.position = new Vector2(transform.position.x, respwanTopPos.position.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : ReactiveObj
{
    public float moveSpeed = 50.0f;
    private float speedMultiplier = 100f;
    public bool isStartMov = false;

    private void FixedUpdate()
    {
        if (isStartMov)
        {
            m_rigidbody.velocity = GetDirVec() * Time.fixedDeltaTime * moveSpeed * speedMultiplier;
        }
    }

    public override void ReactStart()
    {
        base.ReactStart();
        isStartMov = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestoryLine")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player")
        {
            if (GameManager._instance.CurPlayer)
            {
                SoundManager._instance.PlayerDeathSound();
                GameManager._instance.CurPlayer.DestoryCharacter();
                GameManager._instance.curPlayerDeath = true;
            }
        }
    }
}



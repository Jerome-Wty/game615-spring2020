using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : ReactiveObj
{
    public GameObject explosion;
    public Animator m_animator;
    private bool startBoom = false;

    private float boomTime = 1f;
    private float boomTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (startBoom)
        {
            boomTimer += Time.deltaTime;
            if (boomTimer >= boomTime)
            {
                StartBoom();
            }
        }
    }

    private void StartBoom()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        explosion.SetActive(true);
        m_animator.SetTrigger("Boom");
        SoundManager._instance.PlayerBoomSound();
        startBoom = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startBoom = true;
        }
    }
}

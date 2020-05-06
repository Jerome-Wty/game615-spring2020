using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : Trigger
{
    public ReactiveObj trap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trap.ReactStart();
            this.DestoryTrigger();
        }
    }
}

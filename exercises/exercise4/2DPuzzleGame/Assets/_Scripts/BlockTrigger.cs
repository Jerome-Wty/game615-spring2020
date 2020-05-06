using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : Trigger
{
    public ReactiveObj plat;
    private SpriteRenderer spriteRender;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.color = Color.white;
    }
    public override void Update()
    {
        if (CheckIsInRange())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                plat.ReactStart();
                spriteRender.color = new Color(0, 77, 33, 255);
                SoundManager._instance.PlayerTriggerSound();
            }
        }
    }
}
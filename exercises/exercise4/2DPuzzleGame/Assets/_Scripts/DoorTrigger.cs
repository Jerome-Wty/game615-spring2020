using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Trigger
{
    public ReactiveObj door;
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
                door.ReactStart();
                spriteRender.color = new Color(0,77,33,255);
                SoundManager._instance.PlayerTriggerSound();
            }
        }
    }

    public override bool CheckIsInRange()
    {
        if (GameManager._instance.CurPlayer && GameManager._instance.curPlayerType == canTrigPlayerType)
        {
            float dis = Vector2.Distance(GameManager._instance.CurPlayer.transform.position, this.transform.position);
            if (dis <= distance)
            {
                return true;
            }
        }
        return false;
    }
}

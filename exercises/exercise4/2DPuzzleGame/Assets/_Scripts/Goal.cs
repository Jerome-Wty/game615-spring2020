using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Trigger
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Update()
    {
        if (canTrigPlayerType == GameManager._instance.curPlayerType && CheckIsInRange())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager._instance.CurPlayer)
                {
                    Debug.Log(GameManager._instance.CurPlayer.name);
                    GameManager._instance.CurPlayer.DestoryCharacterPure();
                    GameManager._instance.SwitchCharacter();
                    GameManager._instance.canSwitch = false;
                    GameManager._instance.goalCount += 1;
                    SoundManager._instance.PlayerDoorSound();
                }
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

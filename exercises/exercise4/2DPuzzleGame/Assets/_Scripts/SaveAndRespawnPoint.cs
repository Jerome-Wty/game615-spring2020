using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndRespawnPoint : Trigger
{
    public float saveDistance = 1.0f;

    public bool isFirstPoint = false;


    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CheckIsInRange())
            {
                SavePoint();
                Debug.Log("Saved");
                SoundManager._instance.PlayerSaveSound();
            }
        }

        if (isFirstPoint && CheckIsInRange())
        {
            SavePoint();
        }

    }

    public void SavePoint()
    {
        Dictionary<PlayerType, Vector2> saveAndRespawnPoint;
        PlayerType curPlayerType;
        saveAndRespawnPoint = GameManager._instance.saveAndRespawnPoint;
        curPlayerType = GameManager._instance.curPlayerType;
        if (!saveAndRespawnPoint.ContainsKey(curPlayerType))
        {
            saveAndRespawnPoint.Add(curPlayerType, this.transform.position);
        }
        else
        {
            saveAndRespawnPoint[curPlayerType] = this.transform.position;
        }
    }

    public void Respawn()
    {
        GameManager._instance.RespawnPlayer();
        //GameManager._instance.CurPlayer.transform.position = GameManager._instance.saveAndRespawnPoint[GameManager._instance.curPlayerType];
    }

    public override bool CheckIsInRange()
    {
        if (GameManager._instance.CurPlayer && GameManager._instance.curPlayerType == canTrigPlayerType)
        {
            float distance = Vector2.Distance(GameManager._instance.CurPlayer.transform.position, this.transform.position);
            if (distance <= saveDistance)
            {
                return true;
            }
        }
        return false;
    }
}

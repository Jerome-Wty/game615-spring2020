using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public PlayerType canTrigPlayerType;

    public float distance = 1.0f;
    void Start()
    {
        
    }

    public virtual void Update()
    {

    }

    protected void DestoryTrigger()
    {
        Destroy(this.gameObject);
    }
    public virtual bool CheckIsInRange()
    {
        if (GameManager._instance.CurPlayer && GameManager._instance.curPlayerType == canTrigPlayerType)
        {
            if (Mathf.Abs(GameManager._instance.CurPlayer.transform.position.x - this.transform.position.x) <= distance)
            {
                return true;
            }
        }
        return false;
    }
}

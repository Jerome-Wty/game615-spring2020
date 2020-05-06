using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager._instance.CurPlayer)
            {
                GameManager._instance.CurPlayer.DestoryCharacter();
                GameManager._instance.curPlayerDeath = true;
            }
        }
    }

    public void DestoryBoomAfterExplosion()
    {
        Destroy(boom.gameObject);
    }

}

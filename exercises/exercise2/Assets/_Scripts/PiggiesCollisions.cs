using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggiesCollisions : MonoBehaviour
{
    public ScoreManager scoreManager;
    const int TIME_TO_RESET = 3;
    Vector3 originalPosition;
    Transform parent;




    public bool isFirst = true;

    void Start()
    {
        originalPosition = transform.localPosition;
        parent = transform.parent;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirst == true)
        {
            isFirst = false;
            Invoke("ResetPiggy", TIME_TO_RESET);
            if (collision.gameObject.tag != "Floor")
            {
                //scoreManager.PiggyHittingStructure();
               // Debug.Log("Current score: " + scoreManager.getScore());
            }
                //scoreManager.PiggyHittingStructure();
        }
    }

    void ResetPiggy()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.parent = parent;
        transform.localPosition = originalPosition;
        Camera.main.GetComponent<CameraFollow>().resetCameraPosition();
        isFirst = true;
    }
}

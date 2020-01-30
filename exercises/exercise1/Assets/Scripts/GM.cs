using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour{

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public static GM instance = null;

    private GameObject clonePaddle;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        Setup();

    }
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, bricksPrefab.transform.position, Quaternion.identity);

    }


    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }
    // Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public PlayerType curPlayerType;

    public CharacterController2D playerA;
    public CharacterController2D playerB;

    public GameObject playerAPrefab;
    public GameObject playerBPrefab;


    public bool curPlayerDeath = false;
    public int playerALive = 2;
    public int playerBLive = 2;
    public int goalCount = 0;

    public CinemachineVirtualCamera topVcm;
    public CinemachineVirtualCamera botVcm;

    private CharacterController2D curPlayer;

    public CharacterController2D CurPlayer { get => curPlayer; set => curPlayer = value; }

    public Dictionary<PlayerType, Vector2> saveAndRespawnPoint = new Dictionary<PlayerType, Vector2>();

    //Player respawn Time
    public float respawnTime = 1.0f;
    private float respawnTimer = 0.0f;

    public bool canSwitch = true;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curPlayer = playerA;
        InitGameState();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchCharacter();
        }
    }
    private void FixedUpdate()
    {
        if (curPlayerDeath)
        {
            canSwitch = false;
            respawnTimer += Time.fixedDeltaTime;
            if (respawnTimer >= respawnTime)
            {
                if (playerALive <= 0 || playerBLive <= 0)
                {
                    ReloadScene();
                }
                else
                {
                    RespawnPlayer();
                    respawnTimer = 0.0f;
                    canSwitch = true;
                }
            }
        }

        if (goalCount == 2)
        {
            Time.timeScale = 0.1f;
            UIManager._instance.ShowGoalMessage();
        }

    }

    public void SwitchCharacter()
    {
        if (canSwitch)
        {
            curPlayerType = (curPlayerType == PlayerType.A) ? PlayerType.B : PlayerType.A;
            curPlayer = (curPlayerType == PlayerType.A) ? playerA : playerB;
        }
    }

    public void RespawnPlayer()
    {
        if (curPlayerType == PlayerType.A)
        {
            GameObject a = Instantiate(playerAPrefab, saveAndRespawnPoint[curPlayerType], Quaternion.identity);
            playerA = a.GetComponent<CharacterController2D>();
            curPlayer = playerA;
            topVcm.Follow = curPlayer.transform;
        }
        else if (curPlayerType == PlayerType.B)
        {
            GameObject b = Instantiate(playerBPrefab, saveAndRespawnPoint[curPlayerType], Quaternion.identity);
            playerB = b.GetComponent<CharacterController2D>();
            curPlayer = playerB;
            botVcm.Follow = curPlayer.transform;
        };
        curPlayerDeath = false;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InitGameState()
    {
        playerALive = 5;
        playerBLive = 5;
        UIManager._instance.UpdateALive(playerALive);
        UIManager._instance.UpdateBLive(playerBLive);
    }

    public void UpdateLiveAndUI(int liveNum)
    {
        if (curPlayerType == PlayerType.A)
        {
            playerALive = liveNum;
            UIManager._instance.UpdateALive(liveNum);
        }
        else if (curPlayerType == PlayerType.B)
        {
            playerBLive = liveNum;
            UIManager._instance.UpdateBLive(liveNum);
        }

    }

    public int GetCurplayerLive()
    {
        if (curPlayerType == PlayerType.A)
        {
            return playerALive;
        }
        else if (curPlayerType == PlayerType.B)
        {
            return playerBLive;
        }
        return 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public Text playerALive;

    public Text playerBLive;

    public GameObject goalView;

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickSwitchBtn()
    {
        GameManager._instance.SwitchCharacter();
    }

    public void UpdateALive(int liveNum)
    {
        playerALive.text = liveNum.ToString();
    }

    public void UpdateBLive(int liveNum)
    {
        playerBLive.text = liveNum.ToString();
    }

    public void ShowGoalMessage()
    {
        goalView.SetActive(true);
    }
}

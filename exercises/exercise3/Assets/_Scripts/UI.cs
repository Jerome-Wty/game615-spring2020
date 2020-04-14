using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void White()
    {
        GameState.playerColor = "White";
        AI.ai_player = "Black";
        InputController.playerColor = "White";
        SceneManager.LoadScene("Main");
    }

    public void Black()
    {
        GameState.playerColor = "Black";
        AI.ai_player = "White";
        InputController.playerColor = "Black";
        SceneManager.LoadScene("Main");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

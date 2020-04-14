using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInteraction : MonoBehaviour
{
    public void loadLevel()
    {
        // load some scene by name (or, by number)
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoAnimation : MonoBehaviour
{
    const string WhitesPlay = "WhitesPlay";
    const string BlacksPlay = "BlacksPlay";
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.playerColor == "White")
        {
            cameraAnimator.SetTrigger(WhitesPlay);
        }


        if (GameState.playerColor == "Black")
        {
            cameraAnimator.SetTrigger(BlacksPlay);
        }

    }
}

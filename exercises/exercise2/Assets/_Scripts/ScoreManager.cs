using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    const int STUCTURE_HIT_POINT = 1;
    const int PIGGY_HIT_STRUCTURE_POINT = 5;

    public Text scoreText;

    public int score = 0;

    public static ScoreManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public int getScore()
    {
        return score;
    }

    public void StructureHittingAnotherStructure()
    {
        score = score + STUCTURE_HIT_POINT;
        scoreText.text = score.ToString();
    }
    public void PiggyHittingBird()
    {
        score = score + PIGGY_HIT_STRUCTURE_POINT;
        scoreText.text = score.ToString();
    }

}

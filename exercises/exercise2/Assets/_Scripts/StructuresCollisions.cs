using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructuresCollisions : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnCollisionEnter2D(Collision2D colision)
    {
        scoreManager.StructureHittingAnotherStructure();
        Debug.Log("Current score: " + scoreManager.getScore());
    }
}

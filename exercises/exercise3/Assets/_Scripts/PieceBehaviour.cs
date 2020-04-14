using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PieceBehaviour : MonoBehaviour
{
    public AudioClip walkSound;
    NavMeshAgent agent;
    Animator anim;
    public Transform enemy;
    const int MAX_HEALTH = 100;
    int health = MAX_HEALTH;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // get reference to NavMeshAgent
        anim = GetComponent<Animator>(); // get reference to Animator
    }

    // function called if the piece is under attack
    public void underAttack()
    {
        if (health > 0)
        {
            health--; // reduce health
        }
        
        if (health == 0)
        {
           GameState.eliminatePiece(transform); // ask Game State to eliminate the piece
        }
    }

    // this function is callled from "walk" animation of the pawn. It was associated by just specifying its name
    public void playWalkSound()
    {
        GetComponent<AudioSource>().PlayOneShot(walkSound);
    }

    // Update is called once per frame
    void Update()
    {

        if (!enemy && agent.velocity.magnitude > 0.1f) // if speed (that is magnitute of velocity vector) is not zero, then we are moving
                                             // we actually check whether is greater than some small number, because agents tend to get stuck
                                             // on doors and stuff, so they may be "moving" while they are already at destination
        {
            anim.SetTrigger("walk");         // trigger transition from idle to walk in animation engine
        }

        if (!enemy && agent.velocity.magnitude <= 0.1f) // if agent's velocity is near zero, then piece is not moving, so start animating idle
        {
            anim.SetTrigger("idle");  // trigger animation of idle
        }

        if (enemy) // if the GameState set an enemy for us (the destination piece is occupied by enemy, then 
        {
            anim.SetTrigger("attack"); // trigger attack
            enemy.GetComponent<PieceBehaviour>().underAttack(); // substract health from the enemy's health.
        }

        // when a piece is under attack (that is, loosing health), it should have "attack" animation triggered.
        if (health < MAX_HEALTH)
        {
            anim.SetTrigger("attack"); // trigger defense
        }
    }
}

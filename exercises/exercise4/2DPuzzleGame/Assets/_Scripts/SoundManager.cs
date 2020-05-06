using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

    public AudioClip boomSound;
    public AudioClip jumpSound;
    public AudioClip saveSound;
    public AudioClip deathSound;
    public AudioClip triggerSound;
    public AudioClip doorSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerBoomSound()
    {
        audioSource.PlayOneShot(boomSound);
    }

    public void PlayerJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayerSaveSound()
    {
        audioSource.PlayOneShot(saveSound);
    }

    public void PlayerTriggerSound()
    {
        audioSource.PlayOneShot(triggerSound);
    }

    public void PlayerDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    public void PlayerDoorSound()
    {
        audioSource.PlayOneShot(doorSound);
    }



    private void Awake()
    {
        _instance = this;
    }

    


}

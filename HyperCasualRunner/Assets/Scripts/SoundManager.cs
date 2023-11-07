using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource buttonSound;


    void Start()
    {
        PlayerDetection.onDoorHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += PlayStateChangeSounds;
        Enemy.onRunnerDie += PlayeRunnerDieSound;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorHit -= PlayDoorHitSound;
        GameManager.onGameStateChanged -= PlayStateChangeSounds;
        Enemy.onRunnerDie -= PlayeRunnerDieSound;

    }

    private void PlayStateChangeSounds(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LEVELCOMPLETE)
            levelCompleteSound.Play();
        else if(gameState == GameManager.GameState.GAMEOVER)
            gameOverSound.Play();
    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void PlayeRunnerDieSound()
    {
        runnerDieSound.Play();
    }

    public void DisableSounds()
    {
        doorHitSound.volume = 0;
        runnerDieSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        buttonSound.volume = 0;
    }

    public void EnableSounds()
    {
        doorHitSound.volume = 1;
        runnerDieSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
        buttonSound.volume = 1;
    }


}

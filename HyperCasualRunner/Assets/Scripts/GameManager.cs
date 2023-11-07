using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState{ MENU, GAME, LEVELCOMPLETE, GAMEOVER }
    private GameState gameState;

    public static Action<GameState> onGameStateChanged;

    void Awake() 
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    void Start()
    {
        // PlayerPrefs.DeleteAll();
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }

    public bool IsGameState()
    {
        return gameState == GameState.GAME;
    }
}

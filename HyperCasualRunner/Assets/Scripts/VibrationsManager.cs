using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationsManager : MonoBehaviour
{
    private bool _vibrate;
    void Start()
    {
        PlayerDetection.onDoorHit += Vibrate;
        GameManager.onGameStateChanged += StateChangeVibrate;
        Enemy.onRunnerDie += Vibrate;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorHit -= Vibrate;
        GameManager.onGameStateChanged -= StateChangeVibrate;
        Enemy.onRunnerDie -= Vibrate;

    }

    private void StateChangeVibrate(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LEVELCOMPLETE)
            Vibrate();
        else if(gameState == GameManager.GameState.GAMEOVER)
            Vibrate();
    }

    private void Vibrate()
    {   // This is a fake class        
        // please download the package from this link : 
        // https://assetstore.unity.com/packages/tools/integration/haptic-taptic-feedback-engine-for-vibrations-on-ios-android-139512
        if(_vibrate)
            Taptic.Light();
    }

    public void EnableVibration()
    {
        _vibrate=true;
    }

    public void DisableVibration()
    {
        _vibrate=false;
    }

    
}

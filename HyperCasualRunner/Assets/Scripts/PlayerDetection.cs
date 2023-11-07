using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerDetection : MonoBehaviour
{

    CrowdController crowdController; 
    public static Action onDoorHit;

    void Awake()
    {
        crowdController = GetComponent<CrowdController>();
    }

    void Update()
    {
        // To avoide detecting finish line mutiple times, which affects the lvl number (line 44)
        if(GameManager.instance.IsGameState())
            DetectColliders();
    }


    private void DetectColliders()
    {
        Collider[] detectedCollider = Physics.OverlapSphere(transform.position, crowdController.CrowdRadius());
        
        for(int i=0; i< detectedCollider.Length; i++ )
        {
            if(detectedCollider[i].TryGetComponent(out DoorManager doorManager))
            {
                int bonusAmount = doorManager.GetBonusAmount(transform.position.x);
                BonusType bonusType = doorManager.GetBonusType(transform.position.x);

                doorManager.Disable();
                onDoorHit?.Invoke();

                crowdController.AddBonus(bonusAmount, bonusType);

            }
            else if(detectedCollider[i].tag == "FinishLine")
            {
                // SceneManager.LoadScene(0);
                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
                GameManager.instance.SetGameState(GameManager.GameState.LEVELCOMPLETE);
            }
            else if(detectedCollider[i].tag == "Coins")
            {
                Destroy(detectedCollider[i].gameObject);
                DataManager.Instance.AddCoin(1);
            }

        }

    }
}

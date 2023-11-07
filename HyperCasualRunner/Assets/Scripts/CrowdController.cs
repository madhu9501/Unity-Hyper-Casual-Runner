using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    PlayerAnimator playerAnimator;
    [SerializeField]
    private Transform _runnerParent;
    [SerializeField]
    private GameObject _runnerPrefab;
    [SerializeField]
    private float _radiusConst;
    [SerializeField]
    private float _angle;

    void Awake(){
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    void Update()
    {
        if(!GameManager.instance.IsGameState()) return;
        
        PlaceRunner();

        if(_runnerParent.childCount <= 0)
            GameManager.instance.SetGameState(GameManager.GameState.GAMEOVER);
    }

    private void PlaceRunner()
    {
        for(int i=0; i < _runnerParent.childCount; i++){
            Vector3 childPos = GetLocalRunnerPos(i);
            _runnerParent.GetChild(i).localPosition = childPos;
        }

    } 

    //https://en.wikipedia.org/wiki/Fermat%27s_spiral#The_golden_ratio_and_the_golden_angle 
    private Vector3 GetLocalRunnerPos(int index)
    {
        float x = _radiusConst * Mathf.Sqrt(index) * Mathf.Cos( index * _angle * Mathf.Deg2Rad);
        float z = _radiusConst * Mathf.Sqrt(index) * Mathf.Sin( index * _angle * Mathf.Deg2Rad);
        return new Vector3(x,0,z);

    }

    public float CrowdRadius()
    { 
        return _radiusConst * Mathf.Sqrt(_runnerParent.childCount);
    }

    public void AddBonus(int bonusAmount, BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.ADDITION:
                AddRuners(bonusAmount);
                break;
            
            case BonusType.MULTIPLICATION:
                int runnersToAdd = (_runnerParent.childCount * bonusAmount) - _runnerParent.childCount;
                AddRuners(runnersToAdd);
                break;

            case BonusType.SUBSTRACTION:
                RemoveRunner(bonusAmount);
                break;
                      
            case BonusType.DIVISION:
                int runnersToRemove = _runnerParent.childCount - (_runnerParent.childCount /  bonusAmount);
                RemoveRunner(runnersToRemove);
                break;
        }
    }


    private void RemoveRunner(int bonusAmount)
    {
        // if (_runnerParent.childCount == 1)  return

        if(bonusAmount > _runnerParent.childCount)
        {
            bonusAmount = _runnerParent.childCount;
        }
        int runnerAmount =_runnerParent.childCount;
        for( int i = runnerAmount-1  ; i >= runnerAmount - bonusAmount; i--)
        {
            Transform runnerToDestroy = _runnerParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }

    private void AddRuners(int bonusAmount)
    {
        for( int i =0; i < bonusAmount; i++)
        {
            Instantiate(_runnerPrefab, _runnerParent);
        }
        playerAnimator.Run();
    }
}

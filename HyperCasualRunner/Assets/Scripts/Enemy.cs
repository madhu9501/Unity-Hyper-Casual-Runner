using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState{ IDLE, RUN}
    EnemyState enemyState;
    [SerializeField] float _searchRadius;
    [SerializeField] float moveSpeed;
    Transform targetRunner;

    public static Action onRunnerDie;

    // Update is called once per frame
    void Update()
    {
        ManageState();
        
    }

    private void ManageState()
    {
        switch(enemyState)
        {
            case EnemyState.IDLE:
                SearchTarget();
                break;

            case EnemyState.RUN:
                FollowTarget();
                break;      
        }
    }

    private void SearchTarget()
    {
        Collider[] colliderDetected = Physics.OverlapSphere(transform.position, _searchRadius);
        for(int i =0; i < colliderDetected.Length; i++)
        {
            if(colliderDetected[i].TryGetComponent(out Runner runner))
            {
                if(runner.IsTarget()) 
                    continue;

                runner.SetTarget();
                targetRunner = runner.transform;
                SwitchState();
                return;
                
            }
        }
    }

    private void SwitchState()
    {
        enemyState = EnemyState.RUN;
        GetComponent<Animator>().Play("Run");
    }

    private void FollowTarget()
    {
        if(targetRunner == null) return;

        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetRunner.position)< 0.1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
            onRunnerDie?.Invoke();
        }
    }
}

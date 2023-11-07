using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] Transform _enemyParent;
    [SerializeField] int _enemyCount;
    [SerializeField] float _radiusConst;
    [SerializeField] int _angle;

    void Start()
    {
        GenerateEnemy();
    }
    private Vector3 GetLocalEnemyPos(int index)
    {
        float x = _radiusConst * Mathf.Sqrt(index) * Mathf.Cos( index * _angle * Mathf.Deg2Rad);
        float z = _radiusConst * Mathf.Sqrt(index) * Mathf.Sin( index * _angle * Mathf.Deg2Rad);
        return new Vector3(x,0,z);

    }
    void GenerateEnemy()
    {
        for(int i=0; i < _enemyCount; i++)
        {
            Vector3 enemyLocalPos = GetLocalEnemyPos(i);
            Vector3 enemyWorldPos =transform.TransformPoint(enemyLocalPos);
            Instantiate(_enemyPrefab, enemyWorldPos, Quaternion.identity, _enemyParent);
        }

    }
    
}

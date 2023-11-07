using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Text mesh Pro
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _crowdCounterText;
    [SerializeField]
    private Transform _runnerParent;

    void Update()
    {
        _crowdCounterText.text = _runnerParent.childCount.ToString();
        if(_runnerParent.childCount <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}

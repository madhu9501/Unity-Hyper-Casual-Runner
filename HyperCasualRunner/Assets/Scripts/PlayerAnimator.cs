using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    Transform _runnerParent; 


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run()
    {
        for( int i =0; i < _runnerParent.childCount; i++)
        {
            Transform runner = _runnerParent.GetChild(i);
            Animator animator = runner.GetComponent<Animator>();
             
            animator.Play("Run");
        } 
    }

    public void Idle()
    {
        for( int i =0; i < _runnerParent.childCount; i++)
        {
            Transform runner = _runnerParent.GetChild(i);
            Animator animator = runner.GetComponent<Animator>();
             
            animator.Play("Idle");
        }
    }


}

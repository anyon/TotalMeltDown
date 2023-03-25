using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    void Start()
    {
        if( _animator == null )
            _animator = GetComponent<Animator>();
    }

    public void SetTrigger(string paramName)
    {
        _animator.SetTrigger(paramName);
    }

    public void SetBool(string paramName, bool param)
    {
        _animator.SetBool(paramName, param);
    }

    public void SetFloat(string paramName, float param)
    {
        _animator.SetFloat(paramName, param);
    }

    public void SetInt(string paramName, int param)
    {
       _animator.SetInteger(paramName, param);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterAnimation : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private AnimationController _controller;

    [SerializeField]
    private string _movingAnimationName;
    [SerializeField]
    private string _attackingAnimationName;

    private void FixedUpdate()
    {
        if(_rigidbody != null && _controller != null)
        {
            _controller.SetFloat(_movingAnimationName,_rigidbody.velocity.magnitude * int.MaxValue );
        }
    }

    public void Attack()
    {
        if(_controller != null)
        {
            _controller.SetTrigger(_attackingAnimationName);
        }
    }
}
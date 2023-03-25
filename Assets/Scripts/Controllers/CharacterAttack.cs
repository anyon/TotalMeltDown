using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackRate = 1.0f;

    [SerializeField]
    private CharacterAnimation _characterAnimation;

    private float _lastAttack = 1.0f;

    public void Attack()
    {
        if(_characterAnimation != null && Time.time - _lastAttack > _attackRate) 
        {
            _characterAnimation.Attack();
            _lastAttack = Time.time;
        }
    }

}
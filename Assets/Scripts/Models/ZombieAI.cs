using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieAI : Character
{
    [SerializeField]
    private CharacterAttack _characterAttack;
    [SerializeField]
    private float _attackDistance = 1.0f;
    [SerializeField]
    private NavMeshAgent _navAgent;
    private List<Transform> _targets;


    private void Start()
    {
        if (_navAgent == null)
        {
            _navAgent = new NavMeshAgent();
        }
        _targets = new List<Transform>();
    }

    private void FixedUpdate()
    {
        if (_targets.Count > 0)
        {
            Vector3 targetPosition = _targets[0].position;
            _navAgent.SetDestination(targetPosition);

            float distanceToAttackTarget = Vector3.Distance(transform.position, targetPosition);
            if(distanceToAttackTarget <= _attackDistance && _characterAttack != null)
            {
                _characterAttack.Attack();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null && other.GetComponent<ZombieAI>() == null)
        {
            _targets.Add(character.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(_targets.Count > 0 && character != null)
        {
            _targets.Remove(character.transform);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : Character
{
    [SerializeField]
    private JumpPhysics _jumpPhysics;
    [SerializeField]
    public float _jumpDelayMin = 1.0f;
    public float _jumpDelayMax = 5.0f;

    private List<Transform> _zombieAIs;

    private void Start()
    {
        _zombieAIs = new List<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ZombieAI zombieAI = other.GetComponent<ZombieAI>();
        if(zombieAI != null) 
        {
            _zombieAIs.Add(zombieAI.transform);
        } else if (other.GetComponent<Obstacle>() != null)
        {
            Debug.Log("jump");
            StartCoroutine(JumpAfterDelay());

        }
    }

    private IEnumerator JumpAfterDelay()
    {
        //yield return new WaitForSeconds(Random.Range(_jumpDelayMin, _jumpDelayMax));
        Debug.Log("jump2");
        if ( _jumpPhysics != null)
        {
            Debug.Log("jump3");
            _jumpPhysics.Jump();
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        ZombieAI zombieAI = other.GetComponent<ZombieAI>();
        if (zombieAI != null)
        {
            _zombieAIs.Remove(zombieAI.transform);
        }
    }

    private void FixedUpdate()
    {
        if (_jumpPhysics != null)
        {
            _jumpPhysics.Jump();
        }
    }
}

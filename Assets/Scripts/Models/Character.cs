using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float _health = 100.0f;

    [SerializeField]
    private float _damage = 1f;

    [SerializeField]
    private GameObject _mesh;

    [SerializeField]
    private GameObject _ragdollMesh;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            _Die();
        }
    }

     void _Die()
    {
        if(_mesh != null)
        {
            _mesh.SetActive(false);
        }
        if(_ragdollMesh != null)
        {
            _ragdollMesh.SetActive(true);
        }
    }
}

using System.Collections;
using UnityEngine;
public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private Vector3 _direction = Vector3.left;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_direction != Vector3.zero)
        {
            transform.Rotate(_direction * Time.fixedDeltaTime * _speed);
        }
    }
}

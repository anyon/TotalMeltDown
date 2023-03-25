using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private SurfaceSlider _surfaceSlider;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _obstacleDetectionDistance = 1.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        if(directionAlongSurface != Vector3.zero)
        {
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionAlongSurface, out hit, _obstacleDetectionDistance))
            {
                if (Vector3.Dot(directionAlongSurface, hit.normal) < 0.5f)
                {
                    directionAlongSurface = Vector3.zero;
                }
            }

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}
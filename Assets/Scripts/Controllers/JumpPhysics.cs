using System.Collections;
using UnityEngine;

public class JumpPhysics : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _jumpCurve;
    [SerializeField]
    private float _height = 1f;

    private bool _isJumping = false;
    private float _jumpTime = 0f;
    Vector3 _offset = Vector3.zero;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if(!_isJumping)
        {
            _isJumping=true;
            _jumpTime=0f;
            _offset = Vector3.zero;

        }
    }

    private void FixedUpdate()
    {
        
        if (_isJumping)
        {
            _jumpTime += Time.deltaTime;
            float jumpProgress = Mathf.Clamp01(_jumpTime / _jumpCurve.keys[_jumpCurve.length - 1].time);
            float jumpHeight = _jumpCurve.Evaluate(jumpProgress) * _height;
            _offset.y += jumpHeight;

            if (_jumpTime >= _jumpCurve.keys[_jumpCurve.length - 1].time)
            {
                _isJumping = false;
            }
            _rigidbody.MovePosition(_rigidbody.position + _offset);
        }
    }
}

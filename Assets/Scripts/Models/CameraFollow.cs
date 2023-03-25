using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Vector3 _offset = new Vector3(0f, 2f, -10f);
    [SerializeField] 
    private float _smoothTime = 0.3f;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 desiredPosition = _playerTransform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _smoothTime);
        transform.LookAt(_playerTransform);
    }
}

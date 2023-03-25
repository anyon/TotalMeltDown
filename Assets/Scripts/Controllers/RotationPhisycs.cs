
using UnityEngine;

public class RotationPhisycs: MonoBehaviour
{
    [SerializeField]
    private SurfaceSlider _surfaceSlider;
    [SerializeField]
    private float _speed = 5.0f;

    public void Rotate(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(offset);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.fixedDeltaTime);
        }
    }
}

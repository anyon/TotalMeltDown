using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PhysicsMovement _movement;
    [SerializeField]
    private RotationPhisycs _rotationPhisycs;
    [SerializeField]
    private JumpPhysics _jumpPhysics;
    [SerializeField]
    private CharacterAttack _attackCharacter;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(_movement != null)
        {
            _movement.Move(new Vector3(horizontal, 0, vertical));
        }
        if( _rotationPhisycs != null)
        {
            _rotationPhisycs.Rotate(new Vector3(horizontal, 0, vertical));
        }
        if (_jumpPhysics != null&&Input.GetButtonDown("Jump"))
        {
            _jumpPhysics.Jump();
        }
        if (_attackCharacter != null && Input.GetButton("Fire1"))
        {
            _attackCharacter.Attack();
        }

    }
}

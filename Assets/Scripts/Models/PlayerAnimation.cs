using UnityEngine;

[RequireComponent (typeof(Camera))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }

    public void PlayRunAnimation()
    {
        animator.Play("Run");
    }

    public void PlayHitAnimation()
    {
        animator.Play("Hit");
    }
}

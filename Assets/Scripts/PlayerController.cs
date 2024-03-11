using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerControllerBase
{
    public Animator animator;

    private void Awake()
    {
        base.Awake();
        OnJump += Jump;
        OnDie += Die;
    }

    private void Jump(float force)
    {
        rb.velocityY = force;
        animator.SetTrigger("Jump");
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}

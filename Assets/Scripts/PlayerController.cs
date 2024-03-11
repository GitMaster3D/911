using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerControllerBase
{
    private void Awake()
    {
        OnJump += Jump;
        OnDie += Die;
    }

    private void Jump(float force)
    {
        rb.velocityY = force;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}

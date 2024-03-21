using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : PlayerControllerBase
{
    [SerializeField] private Transform Graphics;
    [SerializeField] private float JumpRotateIntensity;
    [SerializeField] private float Smoothtime;

    [SerializeField] private GameObject DeathParticleSystem;



    private Vector2 RotateRefrenceVelocity;
    private Vector2 RotateVec;


    public void Awake()
    {
        base.Awake();
        OnJump += Jump;
        OnDie += Die;
    }


    public void OnValidate()
    {
        // Get Transform of Graphics Object
        if (Graphics == null)
            Graphics = GetComponentInChildren<SpriteRenderer>().gameObject.transform;
    }


    public void Update()
    {
         RotateVec = Vector2.SmoothDamp(
            RotateVec,
            new Vector2(rb.velocityX + JumpRotateIntensity, rb.velocityY),
            ref RotateRefrenceVelocity,
            Smoothtime
            );

        float rotation = Mathf.Atan2(RotateVec.y, RotateVec.x) * Mathf.Rad2Deg;

        Graphics.transform.rotation = Quaternion.Euler(
            0, // X Axis
            0, // Y Axis
            rotation // Z Axis
            );
    }


    private void Jump(float force)
    {
        rb.velocityY = force;
    }


    private void Die()
    {
        Destroy(gameObject);

        var instance = Instantiate(DeathParticleSystem, transform.position, Quaternion.identity);
        instance.GetComponent<ParticleSystem>().Play();
    }

}

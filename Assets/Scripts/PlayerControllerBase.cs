using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerBase : MonoBehaviour
{
    // PUBLIC:

    public float Jumpforce;
    public float JumpCooldown;
    public string ObstacleTag;
    public Action<float> OnJump;
    public Action OnDie;
    public Action OnJumpReady;
    [HideInInspector] public Rigidbody2D rb;



    #region INITIALIZAION
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(PlayerUpdate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    #endregion


    #region INPUTHANDLING
    private IEnumerator PlayerUpdate()
    {
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                OnJump?.Invoke(Jumpforce);
                yield return new WaitForSeconds(JumpCooldown);
                OnJumpReady?.Invoke();
            }

            yield return null;
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ObstacleTag)
            OnDie?.Invoke();
    }
}
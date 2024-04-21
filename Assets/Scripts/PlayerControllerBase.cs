using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerBase : MonoBehaviour
{
    // PUBLIC:

    public static PlayerControllerBase Instance;

    public float Jumpforce;
    public float JumpCooldown;
    public string ObstacleTag;
    [HideInInspector] public Rigidbody2D rb;

    #region EVENTS
    public Action<float> OnJump;
    public Action OnDie;
    public Action OnJumpReady;
    public Action OnGameStarted;
    #endregion


    // PRIVATE:
    private bool GravityActive = false;
    private float DefaultGravityScale;

    #region INITIALIZAION
    public void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        DefaultGravityScale = rb.gravityScale;

        // Disable gravity to give player a chance to start the game
        StopGravity();
    }

    public void OnEnable()
    {
        StartCoroutine(PlayerUpdate());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }
    #endregion


    #region INPUTHANDLING
    private IEnumerator PlayerUpdate()
    {
        while (true)
        {
            // Start Game When Player presses Space
            if (!GravityActive && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                StartGravity();
                OnGameStarted?.Invoke();
            }


            // Jump When Player PResses Space
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                OnJump?.Invoke(Jumpforce);
                yield return new WaitForSeconds(JumpCooldown);
                OnJumpReady?.Invoke();
            }

            yield return null;
        }
    }
    #endregion




    public void StartGravity()
    {
        rb.gravityScale = DefaultGravityScale;
    }


    public void StopGravity()
    {
        rb.gravityScale = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ObstacleTag)
            OnDie?.Invoke();
    }
}
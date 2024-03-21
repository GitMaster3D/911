using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    // Public:
    [HideInInspector] public float timer;
    public float ttl;
    public List<GameObject> babalist;


    // Private:
    private bool running = true;


    void Start(){
        timer =ttl;

        PlayerControllerBase.Instance.OnDie += () =>
        {
            running = false;
        };
    }


    // Update is called once per frame
    void Update()
    {
        if (!running) return;

        timer -= Time.deltaTime;
        if(timer<= 0){
            timer = ttl;
            Destroy(gameObject);
            babalist.Remove(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    [HideInInspector    ]public float timer;
    public float ttl;
    public List<GameObject> babalist;
    void Start(){
        timer =ttl;
    }
    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer<= 0){
            timer = ttl;
            Destroy(gameObject);
            babalist.Remove(gameObject);
        }
    }
}

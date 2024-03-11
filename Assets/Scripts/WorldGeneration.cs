using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public Vector3 vector;
    public GameObject obstical;

    public float timer;
    public float spawndelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer <=0){
            list.Add(Instantiate(obstical));
        
            timer = spawndelay;
        }
        foreach(var obj in list){
            obj.transform.position += vector*Time.deltaTime;
        }
        
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class WorldGeneration : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public Vector3 vector;
    public Vector3 vector3;
    public GameObject obstical;

    public double timer;
    public float lifeTimer;
    public double spawndelay;
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerBase.Instance.OnDie += () =>
        {
            list.Clear();
            Destroy(gameObject);
        };
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer <=0){
            var obj = Instantiate(obstical);
            obj.GetComponent<TimeToLive>().babalist = list;
            list.Add(obj);
            vector3.y = Random.Range(-2.5f,2.5f);
            obj.transform.position += vector3 ;
            if(spawndelay>2f){
                spawndelay -= 0.1;
            }
            
            timer = spawndelay;
        }
        foreach(var obj in list){
            obj.transform.position += vector*Time.deltaTime;
        }
    }
}
